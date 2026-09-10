# ProfileFillingTool

A Windows Forms utility for filling meter load profiles through DLMS/COSEM communication.

The tool supports optical communication, IEC 1107 startup, and network communication. It can use password or GMAC authentication and supports the configured DLMS/COSEM client associations.

## Requirements

- Windows
- .NET Framework 4.8 Developer Pack
- Visual Studio with the .NET desktop development workload, or a compatible MSBuild installation
- Access to the referenced shared projects:
  - `Common\Common.csproj`
  - `Core\Core.csproj`
- Access to the Iskraemeco device and communication libraries referenced by `ProfileFillingTool.csproj`
- A supported meter and either an available serial connection or reachable meter IP address

The project currently references some assemblies from a network share. A build can therefore fail when that share or the referenced shared projects are unavailable.

## Build

Open a Visual Studio Developer PowerShell in this directory and run:

```powershell
msbuild ProfileFillingTool.csproj /t:Build /p:Configuration=Debug
```

To build a release configuration:

```powershell
msbuild ProfileFillingTool.csproj /t:Build /p:Configuration=Release
```

The output is written to `bin\Debug\` or `bin\Release\`.

## Run

1. Build the project with the required shared projects and device libraries available.
2. Start `bin\Debug\ProfileFillingTool.exe` or run the project from Visual Studio.
3. Select serial or network communication.
4. Configure the communication port or IP address, association, authentication mode, and required credentials.
5. Review the profile entries and start the profile-filling operation.

Test connection settings and profile targets carefully before writing to a production meter. Meter profile writes may change device data and should be performed only by authorized users.

## Configuration and security

Default UI values are stored in `App.config` and the generated application settings. The repository currently contains example password and key values for development. Replace them with approved, environment-specific values before using the tool with a real meter, and do not commit real credentials or encryption keys.

Do not include passwords, authentication keys, encryption keys, or raw protocol data in logs, screenshots, issue reports, or source control.

## Project layout

- `Form1.cs` - WinForms event handlers, connection setup, and profile-filling workflow
- `Form1.Designer.cs` - generated WinForms control layout
- `Program.cs` - application entry point
- `Properties/` - application resources and settings
- `ProfileFillingTool.csproj` - project and external assembly references
- `.github/agents/` - workspace custom agent definitions

## Troubleshooting

### Missing project or namespace references

Verify that the referenced `Common` and `Core` projects exist at the paths configured in `ProfileFillingTool.csproj`. Also verify access to the network share containing the Iskraemeco libraries.

### No serial ports are listed

Check the USB/optical adapter, its driver, and whether another application is using the port. Restart the application after connecting the adapter so the port list is refreshed.

### Network communication fails

Verify the meter IP address, port, firewall rules, association, authentication mode, and encryption values. The default network port configured by the application is `4059`.
