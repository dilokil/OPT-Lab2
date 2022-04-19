using System.Text;

namespace Lab_2._3
{
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pas files (*.pas)|*.pas| All files (*.*)| *.*";
            if (ofd.ShowDialog() == DialogResult.OK) {
                textBox.Text = File.ReadAllText(ofd.FileName, Encoding.Default);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void checkProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            Parser parser = new Parser();
            bool result = parser.CheckProgramText(textBox.Text);

            MessageBox.Show(result ? 
                               "Программа прошла проверку"    
                               : "Программа не прошла проверку\n" + "Неожиданный символ в " + parser.ErrorIndex + " строке", "Проверка окончена!");
            
            textBox.SelectionStart = parser.indexOfNowStartLine + 1;
            textBox.SelectionLength = parser.indexOfNowEndLine - parser.indexOfNowStartLine;
            textBox.Focus();
            
        }
    }
}