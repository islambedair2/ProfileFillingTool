# ProfileFillingTool Function Description

## Purpose

`ProfileFillingTool` is a Windows Forms application for writing synthetic or missing load-profile timestamps to a compatible meter through DLMS/COSEM communication.

The application connects to a meter, optionally resets configured load profiles, writes clock values at the requested capture interval, and reports the operation status and elapsed time.

Profile filling writes to the meter clock object `0.0.1.0.0.255` and targets the following load-profile objects when profile reset is enabled:

- `1.0.99.1.0.255`
- `1.0.99.2.0.255`
- `1.0.99.1.1.255`
- `1.0.99.2.1.255`
- `0.0.98.1.0.255`
- `0.0.98.2.0.255`
- `1.0.99.14.0.255`

## User Interface

### Communication settings

| Field | Description |
| --- | --- |
| `ComPort` | Serial port used for optical communication. The list is populated from the ports available when the application starts. |
| `BaudRate` | Serial communication speed. Available values are `300`, `9600`, `38400`, `57600`, and `115200`. |
| `Server IP` | Meter IP address used when `Use Network` is selected. |
| `Use Network` | Selects network DLMS communication instead of serial optical communication. The application uses TCP port `4059`. |
| `Use 1107` | Enables IEC 1107 optical startup. When selected, communication starts at `300` baud and changes to the selected maximum baud rate. This option is unavailable in network mode. |

### Authentication and encryption

| Field | Description |
| --- | --- |
| `Encryption Mode` | Selects `Password` or `GMAC`. |
| `Device Password` | Password used with `Password` authentication. It is enabled only in Password mode. |
| `Encryption Key` | Encryption key used with GMAC. It is enabled only in GMAC mode. |
| `Authenticat. Key` | Authentication key used with GMAC. It is enabled only in GMAC mode. |
| `Use Association` | DLMS client association. Available associations are `1 - Management`, `21 - Security Officer`, and `7 - Role 7`. |

In Password mode, payload encryption is disabled and password association encryption is used. In GMAC mode, encryption and authentication are enabled for the association and payload.

### Profile schedule grid

Each grid row describes one sequence of profile timestamps.

| Column | Description |
| --- | --- |
| `Capture Period` | Positive numeric interval between generated entries. |
| `Period Unit` | `Second`, `Minute`, `Hour`, `Day`, `Month`, or `Year`. |
| `Profile Entries` | Number of timestamps to write for the row. |

The last blank DataGridView row is used for entering a new row and is not processed. At least one completed row is required before starting the operation.

### Operation options

| Option | Description |
| --- | --- |
| `Fill Till Now` | Backdates the meter before writing, then fills entries forward until the current time and synchronizes the meter clock again. |
| `Reset Profiles Before Fill` | Calls the `Reset` method on each configured load-profile object before writing. Failures from individual reset calls are currently ignored by the application. |
| `Fill Profiles` | Builds the communication request and starts the profile-filling workflow. The button is disabled while the operation is running. |
| Progress label | Shows `None`, `In Progress`, `Aborted`, or `Done`, and reports completed grid rows. |

## How to Use

### 1. Prepare the environment

1. Connect the supported optical adapter or ensure that the meter is reachable over the network.
2. Confirm that the application was built with all required Iskraemeco DLMS/COSEM libraries and shared projects available.
3. Ensure that the selected association and credentials are authorized to write the meter clock and profile data.
4. Back up or record any meter data that must be preserved before using reset or write operations.

### 2. Configure communication

For serial optical communication:

1. Leave `Use Network` unchecked.
2. Select the meter's COM port.
3. Select the normal baud rate.
4. Check `Use 1107` only when the meter requires IEC 1107 startup.
5. Select the association and authentication mode.
6. Enter the password, or enter both GMAC keys when GMAC is selected.

For network communication:

1. Check `Use Network`.
2. Enter the meter IP address in `Server IP`.
3. Do not configure the serial port or `Use 1107`; those controls are disabled in network mode.
4. Select the association and authentication mode, then enter the required credentials or keys.

### 3. Define the profile schedule

Add one or more completed rows to the grid. For each row:

1. Enter the capture interval, for example `15`.
2. Select the interval unit, for example `Minute`.
3. Enter the number of entries to create, for example `96`.

For a 15-minute profile with 96 entries, the tool generates 96 clock timestamps separated by 15 minutes. Multiple rows are processed in order.

### 4. Choose the time and reset behavior

Use `Reset Profiles Before Fill` only when existing data in the configured load profiles should be reset first.

Use `Fill Till Now` when the desired result should cover the interval from a calculated historical start time through the current time:

1. The application synchronizes the meter clock.
2. It moves the clock backward by the total schedule represented by all grid rows.
3. It rejects the operation if the calculated time is earlier than `2000-01-01 00:00:00`.
4. It writes the configured rows.
5. On the last row, it continues writing timestamps until the current UTC time and synchronizes the meter clock again.

When `Fill Till Now` is unchecked, the application reads the meter time and writes the configured rows forward from that time. It does not perform the initial historical backdating step.

### 5. Start and monitor the operation

1. Confirm all communication, credential, and schedule values.
2. Click `Fill Profiles`.
3. Wait for the progress label to report completion. Do not close the application or disconnect the meter while writes are in progress.
4. On success, the application shows the elapsed time and the meter time read after the operation.
5. If communication or input setup fails, the application shows an input/communication error message. A failed time read or synchronization changes the status to `Aborted`.

Each schedule row is processed asynchronously so the UI remains responsive. The application waits approximately five seconds between completed rows.

## Time Generation Rules

For normal profile filling, each generated timestamp is based on the current meter time and advances by the selected capture period:

- Seconds use second-based increments.
- Minutes use minute-based increments.
- Hours use hour-based increments.
- Days use calendar-day increments.
- Months use calendar-month increments.
- Years use calendar-year increments.

Timestamps are written through the meter clock object. The current implementation converts the meter time to local time before generating values and writes the resulting COSEM date-time value. Daylight-saving and time-zone edge cases should therefore be validated against the target meter before production use.

For `Fill Till Now`, month intervals are approximated as 30 days when calculating the catch-up loop. Year intervals are not converted into a fixed number of seconds in that loop, so year-based catch-up should be tested carefully.

## Configuration Persistence

Several controls are bound to user settings and are saved when the application closes, including:

- COM port
- Baud rate
- Device password
- Encryption mode
- Association
- IEC 1107 selection
- Network/serial selection

The application configuration contains development/sample credential and key values. Replace them with approved environment-specific values before connecting to a real meter. Never commit real credentials or keys.

## Safety and Operational Notes

- Profile filling changes data in a physical meter and should be performed only by authorized personnel.
- `Reset Profiles Before Fill` can remove existing profile data from the configured profile objects.
- Verify the meter, association, credentials, schedule, and time assumptions before clicking `Fill Profiles`.
- Do not disconnect the meter, close the application, or interrupt power during a write operation.
- The application does not provide a separate dry-run mode or cancellation button.
- Reset exceptions are currently suppressed, so verify the resulting profile contents after an operation.
- The application does not validate every grid value before starting. Invalid or incomplete values can cause the operation to fail and display the generic input error message.
- Network communication uses the fixed port `4059`.

## Troubleshooting

### The COM port list is empty

Connect the adapter before starting the application, check its driver, and close other programs that may be using the port. Restart the application after changing the adapter connection.

### The application cannot read meter time

Check the selected transport, COM port or IP address, baud rate, association, authentication mode, password, and keys. Confirm that the selected association has permission to read the meter clock.

### IEC 1107 communication fails

Enable `Use 1107`, select the correct COM port, and ensure the meter supports startup at `300` baud followed by the selected maximum baud rate.

### GMAC communication fails

Select `GMAC` and provide both the encryption key and authentication key in the format expected by the meter. Confirm that the selected association and key pair are valid.

### The operation is aborted before writing

The application aborts when it cannot read or synchronize meter time, or when the calculated historical start time would be earlier than `2000-01-01`.

### The build fails before the application starts

Check that `Common\Common.csproj`, `Core\Core.csproj`, and the referenced device-library assemblies are available at the paths configured in `ProfileFillingTool.csproj`. Some dependencies are located on a network share.
