using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO.Ports;

// calculated values
// parameter    7 inch (33.3 rpm)           7 inch (45 rpm)     10 inch (33.3 rpm)      10 inch (45 rpm)    12 inch (33.3 rpm)  12 inch (45 rpm)
// run-in       (length (cm) * 10) / time   <                    <                      <                   <                   <
// run          0.6 mm/s	                1 mm/s	             0.55 mm/s	            0.9 mm/s	        0.5 mm/s            0.8 mm/s
// band         (length (cm) * 10) / time   <                    <                      <                   <                   <
// run-out      (length (cm) * 10) / time   <                    <                      <                   <                   <

// starting values
// parameter       7 inch (33.3 rpm)      7 inch (45 rpm)      10 inch (33.3 rpm)      10 inch (45 rpm)    12 inch (33.3 rpm)  12 inch (45 rpm)
// run in spiral    5 mm/s                 7 mm/s               5 mm/s                  7 mm/s              5 mm/s              7 mm/s
// song movement    0.6 mm/s               1 mm/s               0.55 mm/s               0.9 mm/s            0.5 mm/s            0.8 mm/s
// band space       1.5 mm/s               2 mm/s               1.5 mm/s                2 mm/s              1.5 mm/s            2 mm/s
// run out spiral   6 mm/s                 8 mm/s               6 mm/s                  8 mm/s              6 mm/s              8 mm/s

namespace VinylBurner {
    public partial class MainForm : MaterialForm {
        private MaterialSkinManager materialSkinManager;

        private static SerialPort? _serialPort;
        private bool tingyr = false;
        private bool tingyg = false;
        private bool tingyb = false;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            SerialPort sp = (SerialPort)sender;
            string incomingData = sp.ReadLine().TrimEnd('\r');

            this.Invoke(new Action(() => {
                
            }));
        }

        public MainForm() {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            _serialPort = new SerialPort("COM3", 19200);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //_serialPort.Open();
        }
    }
}
