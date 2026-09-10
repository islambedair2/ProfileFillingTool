using Iskraemeco.Core;
using Iskraemeco.MeterAccess;
using Iskraemeco.MeterView.Driver.Cosem.Model;
using Iskraemeco.Testing.Common;
using Iskraemeco.Testing.Core;
using ProfileFillingTool.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfileFillingTool
{
    public partial class ProfileFillingTool : Form
    {
        private readonly static List<KeyValuePair<string, string>> _associations = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("1", "1 - Management"),
            new KeyValuePair<string, string>("21", "21 - Security Officer"),
            new KeyValuePair<string, string>("7", "7 - Role 7")
        };

        private MasRequest _opticalRequest;

        private readonly string _loadProfile1 = "1.0.99.1.0.255";
        private readonly Stopwatch _stopWatch = new Stopwatch();

        //private int TotalProfileEntries
        //{
        //    get
        //    {
        //        return dgv.Rows.Cast<DataGridViewRow>().Sum(r => Convert.ToInt32(r.Cells["profileEntries"].Value));
        //    }
        //}

        private void EnableDisableFields()
        {
            string encMode = cbEncryptMode.SelectedItem.ToString();

            if (cbUseNetwork.Checked)
            {
                cbUse1107.Enabled = false;
                cbBaudRate.Enabled = false;
                cbComPorts.Enabled = false;

                tbServerIp.Enabled = true;
            }
            else
            {
                cbUse1107.Enabled = true;
                cbBaudRate.Enabled = true;
                cbComPorts.Enabled = true;

                tbServerIp.Enabled = false;
            }

            switch (encMode)
            {
                case "Password":
                    //Enables
                    tbDevicePassword.Enabled = true;

                    //Disables / Clears text
                    tbEncryptKey.Enabled = false;
                    tbEncryptKey.Text = string.Empty;
                    tbAuthKey.Enabled = false;
                    tbAuthKey.Text = string.Empty;
                    break;

                case "GMAC":
                    //Enables
                    tbEncryptKey.Enabled = true;
                    tbAuthKey.Enabled = true;

                    //Disables / Clears text
                    tbDevicePassword.Enabled = false;
                    tbDevicePassword.Text = string.Empty;
                    break;
            }
        }

        private void cbEncryptMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableFields();
        }

        public ProfileFillingTool()
        {            
            InitializeComponent();

            EnableDisableFields();

            cbComPorts.DataSource = SerialPort.GetPortNames().ToList();

            var bindingSource = new BindingSource(_associations, null);
            cbAssociation.DataSource = bindingSource;
            cbAssociation.DisplayMember = "Value";
            cbAssociation.ValueMember = "Key";
        }

        private void UpdateMasRequest()
        { 
            if (cbUseNetwork.Checked)
            {
                var device = new MasNetworkDlmsCommunication();

                device.Encryption.AuthenticationType = cbEncryptMode.SelectedItem.ToString();
                device.Password = tbDevicePassword.Text;
                device.Encryption.CryptoKey = tbEncryptKey.Text;
                device.Encryption.AuthoKey = tbAuthKey.Text;
                device.ClientAddress = Convert.ToInt32(((KeyValuePair<string, string>)cbAssociation.SelectedItem).Key);
                device.ServerIp = tbServerIp.Text;
                device.ServerPort = 4059;

                if (cbEncryptMode.SelectedItem.ToString() == "Password")
                {
                    device.UseAssociationEncryption = UseAssociationEncryption.Password;
                    device.UsePayLoadEncryption = UsePayLoadEncryption.NoEncryption;
                }
                else
                {
                    device.UseEncryption = true;

                    device.UseAssociationEncryption = UseAssociationEncryption.GMAC;
                    device.UsePayLoadEncryption = UsePayLoadEncryption.EncryptionAndAuthentication;
                }

                _opticalRequest = device.GetRequest();
                _opticalRequest.ClearOperations();
            }
            else
            {
                if (cbUse1107.Checked)
                {
                    var device = new MasOpticalIecDlmsCommunication();

                    device.SetPort(cbComPorts.SelectedItem.ToString());
                    device.BaudRate = 300;
                    device.MaxBaudRate = Convert.ToInt32(cbBaudRate.SelectedItem.ToString());
                    device.Encryption.AuthenticationType = cbEncryptMode.SelectedItem.ToString();
                    device.Password = tbDevicePassword.Text;
                    device.Encryption.CryptoKey = tbEncryptKey.Text;
                    device.Encryption.AuthoKey = tbAuthKey.Text;
                    device.ClientAddress = Convert.ToInt32(((KeyValuePair<string, string>)cbAssociation.SelectedItem).Key);
                    device.Iec1107Mode = cbUse1107.Checked;

                    if (cbEncryptMode.SelectedItem.ToString() == "Password")
                    {
                        device.UseAssociationEncryption = UseAssociationEncryption.Password;
                        device.UsePayLoadEncryption = UsePayLoadEncryption.NoEncryption;
                    }
                    else
                    {
                        device.UseEncryption = true;

                        device.UseAssociationEncryption = UseAssociationEncryption.GMAC;
                        device.UsePayLoadEncryption = UsePayLoadEncryption.EncryptionAndAuthentication;
                    }

                    _opticalRequest = device.GetRequest();
                    _opticalRequest.ClearOperations();
                }
                else
                {
                    var device = new MasOpticalDlmsCommunication();

                    device.SetPort(cbComPorts.SelectedItem.ToString());
                    device.BaudRate = Convert.ToInt32(cbBaudRate.SelectedItem.ToString());
                    device.Encryption.AuthenticationType = cbEncryptMode.SelectedItem.ToString();
                    device.Password = tbDevicePassword.Text;
                    device.Encryption.CryptoKey = tbEncryptKey.Text;
                    device.Encryption.AuthoKey = tbAuthKey.Text;
                    device.ClientAddress = Convert.ToInt32(((KeyValuePair<string, string>)cbAssociation.SelectedItem).Key);
                    device.Iec1107Mode = cbUse1107.Checked;

                    if (cbEncryptMode.SelectedItem.ToString() == "Password")
                    {
                        device.UseAssociationEncryption = UseAssociationEncryption.Password;
                        device.UsePayLoadEncryption = UsePayLoadEncryption.NoEncryption;
                    }
                    else
                    {
                        device.UseEncryption = true;

                        device.UseAssociationEncryption = UseAssociationEncryption.GMAC;
                        device.UsePayLoadEncryption = UsePayLoadEncryption.EncryptionAndAuthentication;
                    }

                    _opticalRequest = device.GetRequest();
                    _opticalRequest.ClearOperations();
                }
            }            
        }

        private async void btnFillProfiles_Click(object sender, EventArgs e)
        {
            btnFillProfiles.Enabled = false;

            try
            {
                UpdateMasRequest();
                await FillProfiles();
            }
            catch
            {
                MessageBox.Show("Make sure your inputs are correct!");
            }
            finally 
            { 
                btnFillProfiles.Enabled = true;
            }
        }

        private async Task FillProfiles()
        {
            if (dgv.RowCount > 1)
            {
                _stopWatch.Restart();

                labelProgress.Text = "Progress: In Progress...";
                if (cbFillTillNow.Checked)
                {

                    _opticalRequest.ClearOperations();
                    bool earlyTime = false;
                    await Task.Run(() => earlyTime = ShiftTime());

                    if (!earlyTime)
                    {
                        labelProgress.Text = "Progress: Aborted";
                        return;
                    }
                }
                else 
                {
                    try
                    {
                        MeterDateTime.ReadTime(_opticalRequest);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could NOT read time. Check communication!");
                        labelProgress.Text = "Progress: Aborted";
                        return;
                    }
                }

                if(cb_ResetProfiles.Checked)
                {
                    _opticalRequest.ClearOperations();
                    foreach (var loadProfile in LoadProfileList)
                    {
                        try
                        {
                            Sep2Connector.ExecuteCosemMethod<CosemProfileGeneric1>
                            (
                                loadProfile,
                                "Reset",
                                _opticalRequest,
                                new CosemNativeInteger(0)
                            );
                        }
                        catch (Exception){ }
                    }
                }

                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    var row = dgv.Rows[i];
                    _opticalRequest.ClearOperations();

                    if (i != dgv.RowCount - 2)
                    {
                        await Task.Run(() => FillProfile(Convert.ToInt32(row.Cells[0].Value),
                                    row.Cells[1].Value.ToString(),
                                    Convert.ToInt32(row.Cells[2].Value), false));
                    }
                    else
                    {
                        await Task.Run(() => FillProfile(Convert.ToInt32(row.Cells[0].Value),
                                    row.Cells[1].Value.ToString(),
                                    Convert.ToInt32(row.Cells[2].Value), cbFillTillNow.Checked));
                    }

                    labelProgress.Text = $"Progress: In Progress... Row {i + 1} / {dgv.RowCount - 1} Finished";
                    await Task.Run(() => Thread.Sleep(5000));
                }

                _stopWatch.Stop();

                MessageBox.Show($"SUCCESS!\n" +
                                $"Time taken: {_stopWatch.Elapsed:hh\\:mm\\:ss}\n" +
                                $"New meter time: {MeterDateTime.ReadTime(_opticalRequest).ToLocalTime()}");

                labelProgress.Text = "Progress: Done";
            }
            else
            {
                MessageBox.Show("DataGridView must not be empty!");
            }
        }       

        private bool ShiftTime()
        {
            try
            {
                MeterDateTime.ClockSynchronize(_opticalRequest);
            }
            catch (Exception)
            {
                MessageBox.Show("Could NOT synchronize time. Check communication!");
                return false;
            }
            
            var meterTimeStart = MeterDateTime.ReadTimeUtcWithDst(_opticalRequest).ToUniversalTime();
            //-1 because of last row (its empty by default)
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                var row = dgv.Rows[i];

                var profileEntries = Convert.ToInt32(row.Cells[2].Value);
                for (int j = 0; j < profileEntries; j++)
                {
                    meterTimeStart = ShiftTimeNew(Convert.ToInt32(row.Cells[0].Value),
                            row.Cells[1].Value.ToString(),
                            Convert.ToInt32(row.Cells[2].Value), meterTimeStart);
                }

                    //meterTimeStart = ShiftTime(Convert.ToInt32(row.Cells[0].Value),
                    //        row.Cells[1].Value.ToString(),
                    //        Convert.ToInt32(row.Cells[2].Value), meterTimeStart);
            }

            var limitTime = new DateTime(2000, 1, 1, 0, 0, 0);
            if (meterTimeStart < limitTime)
            {
                MessageBox.Show("Time trying to be written is before 1.1.2000 which is NOT allowed.");
                return false;
            }
            else
            {
                MeterDateTime.WriteTime(meterTimeStart, _opticalRequest);
                return true;
            }
        }
              

        private DateTime ShiftTimeNew(int capturePeriod, string periodUnit, int profileEntries, DateTime dateTime)
        {
            var startDate = dateTime.ToUniversalTime();
            switch (periodUnit)
            {
                case "Second": return dateTime.AddSeconds(-capturePeriod); 
                case "Minute": return dateTime.AddMinutes(-capturePeriod); 
                case "Hour": return dateTime.AddHours(-capturePeriod); 
                case "Day": return dateTime.AddDays(-capturePeriod); 
                case "Month": return dateTime.AddMonths(-capturePeriod); 
                case "Year": return dateTime.AddYears(-capturePeriod); 
                default: return dateTime; 
            }

            //int leapears = CountLeapYears(startDate, dateTime);
            //dateTime = dateTime.AddDays(-leapears);            

        }

        private int CountLeapYears(DateTime start, DateTime end)
        {         
            int startYear = start.Year;
            int endYear = end.Year;

            int leapYearsCount = 0;

            for (int year = startYear; year >= endYear; year--)
            {
                if (year == startYear && IsLeapYear(year))
                {
                    if(start.Month > 3) leapYearsCount++;
                }
                else if (year == endYear && IsLeapYear(year))
                {
                    if (end.Month <= 3) leapYearsCount++;
                }
                else if (IsLeapYear(year))
                {
                    leapYearsCount++;
                }
            }

            return leapYearsCount;
        }

        private bool IsLeapYear(int year)
        {
            return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
        }

        //TODO: IF system time is different from meter time (dst, time zone)
        //use this objectToWrite.Attributes.Time.Value = new CosemNativeOctetString(newTime.ToCosemUniversalDateTime());
        //add another check box and update FillTillNow section

        private void FillProfile(int capturePeriod, string periodUnit, int profileEntries, bool fillTillNow)
        {
            Thread.Sleep(1000);
            var meterTime = MeterDateTime.ReadTime(_opticalRequest).ToLocalTime();
            var newTime = meterTime.ToUniversalTime();
            var objectsToWrite = new List<CosemObject>();
            for (int i = 0; i < profileEntries; i++)
            {
                var objectToWrite = new CosemClock0("0.0.1.0.0.255");

                newTime = IncrementForPeriodUnit(newTime, periodUnit, capturePeriod);
         
                objectToWrite.Attributes.Time.Value = new CosemNativeOctetString(newTime.ToCosemDateTime());
                //objectToWrite.Attributes.Time.Value = new CosemNativeOctetString(newTime.ToCosemUniversalDateTime());
                objectsToWrite.Add(objectToWrite);                
            }
            Sep2Connector.WriteCosemObjects(objectsToWrite, _opticalRequest);

            //if (fillTillNow && periodUnit.Contains("Second"))
            if (fillTillNow)
            {
                if (periodUnit == "Month") capturePeriod = capturePeriod * 30 * 86400;
                else if (periodUnit == "Day") capturePeriod = capturePeriod * 86400;
                else if (periodUnit == "Hour") capturePeriod = capturePeriod * 3600;
                else if (periodUnit == "Minute") capturePeriod = capturePeriod * 60;

                meterTime = MeterDateTime.ReadTimeUtcWithDst(_opticalRequest).ToUniversalTime();
                var timeNow = DateTime.UtcNow;

                while (meterTime.AddSeconds(capturePeriod) < timeNow)
                {
                    objectsToWrite = new List<CosemObject>();
                    int writeTimeTimes = (int)((timeNow - meterTime).TotalSeconds / capturePeriod);

                    for (int i = 0; i < writeTimeTimes; i++)
                    {
                        var objectToWrite = new CosemClock0("0.0.1.0.0.255");
                        meterTime = meterTime.AddSeconds(capturePeriod);

                        objectToWrite.Attributes.Time.Value = new CosemNativeOctetString(meterTime.ToCosemDateTime());
                        objectsToWrite.Add(objectToWrite);
                    }

                    Sep2Connector.WriteCosemObjects(objectsToWrite, _opticalRequest);
                    Thread.Sleep(10 * 1000);
                    meterTime = MeterDateTime.ReadTimeUtcWithDst(_opticalRequest).ToUniversalTime();
                    timeNow = DateTime.UtcNow;
                }
                MeterDateTime.ClockSynchronize(_opticalRequest);
            }
        }

        private DateTime IncrementForPeriodUnit(DateTime dateTime, string selectedText, int capturePeriod)
        {
            switch (selectedText)
            {
                case "Second": return dateTime.AddSeconds(capturePeriod).ToUniversalTime();
                case "Minute": return dateTime.AddMinutes(capturePeriod).ToUniversalTime();
                case "Hour": return dateTime.AddHours(capturePeriod).ToUniversalTime();
                case "Day": return dateTime.AddDays(capturePeriod).ToUniversalTime();
                case "Month": return dateTime.AddMonths(capturePeriod).ToUniversalTime();
                case "Year": return dateTime.AddYears(capturePeriod).ToUniversalTime();
                default: return dateTime;
            }
        }

        private void ProfileFillingTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void cbFillTillNow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private List<string> LoadProfileList = new List<string>
        {
            "1.0.99.1.0.255", "1.0.99.2.0.255", "1.0.99.1.1.255", "1.0.99.2.1.255", "0.0.98.1.0.255", "0.0.98.2.0.255", "1.0.99.14.0.255"
        };

        private void tbServerIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUseNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseNetwork.Checked)
            {
                cbUse1107.Enabled = false;
                cbBaudRate.Enabled = false;
                cbComPorts.Enabled = false;

                tbServerIp.Enabled = true;
            }
            else
            {
                cbUse1107.Enabled = true;
                cbBaudRate.Enabled = true;
                cbComPorts.Enabled = true;

                tbServerIp.Enabled = false;
            }
        }
    }
}
