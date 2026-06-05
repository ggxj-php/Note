using System;
using System.Windows.Forms;
using Implements;
using API;

namespace UI
{
    public partial class MainForm : Form
    {
        private TextBox txtSourceDir;
        private TextBox txtTargetDir;
        private TextBox txtInputText;
        private TextBox txtResult;
        private Button btnRemoveDup;
        private Button btnSegment;
        private Label lblSource;
        private Label lblTarget;
        private Label lblInput;
        private Label lblResult;
        private GroupBox grpRemoveDup;
        private GroupBox grpSegment;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 窗口设置
            this.Text = "文本处理工具";
            this.Size = new System.Drawing.Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 批量去重分组
            grpRemoveDup = new GroupBox();
            grpRemoveDup.Text = "文本批量去重";
            grpRemoveDup.Location = new System.Drawing.Point(15, 15);
            grpRemoveDup.Size = new System.Drawing.Size(550, 180);

            // 源文件夹标签和文本框
            lblSource = new Label();
            lblSource.Text = "源文件夹路径:";
            lblSource.Location = new System.Drawing.Point(15, 30);
            lblSource.Size = new System.Drawing.Size(100, 20);

            txtSourceDir = new TextBox();
            txtSourceDir.Location = new System.Drawing.Point(120, 30);
            txtSourceDir.Size = new System.Drawing.Size(400, 20);
            txtSourceDir.PlaceholderText = "请输入源文件夹路径";

            // 目标文件夹标签和文本框
            lblTarget = new Label();
            lblTarget.Text = "目标文件夹路径:";
            lblTarget.Location = new System.Drawing.Point(15, 60);
            lblTarget.Size = new System.Drawing.Size(100, 20);

            txtTargetDir = new TextBox();
            txtTargetDir.Location = new System.Drawing.Point(120, 60);
            txtTargetDir.Size = new System.Drawing.Size(400, 20);
            txtTargetDir.PlaceholderText = "请输入目标文件夹路径";

            // 去重按钮
            btnRemoveDup = new Button();
            btnRemoveDup.Text = "开始去重";
            btnRemoveDup.Location = new System.Drawing.Point(15, 100);
            btnRemoveDup.Size = new System.Drawing.Size(100, 30);
            btnRemoveDup.Click += BtnRemoveDup_Click;

            // 添加到分组
            grpRemoveDup.Controls.Add(lblSource);
            grpRemoveDup.Controls.Add(txtSourceDir);
            grpRemoveDup.Controls.Add(lblTarget);
            grpRemoveDup.Controls.Add(txtTargetDir);
            grpRemoveDup.Controls.Add(btnRemoveDup);

            // 中文分词分组
            grpSegment = new GroupBox();
            grpSegment.Text = "中文分词";
            grpSegment.Location = new System.Drawing.Point(15, 205);
            grpSegment.Size = new System.Drawing.Size(550, 250);

            // 输入文本标签和文本框
            lblInput = new Label();
            lblInput.Text = "输入文本:";
            lblInput.Location = new System.Drawing.Point(15, 30);
            lblInput.Size = new System.Drawing.Size(60, 20);

            txtInputText = new TextBox();
            txtInputText.Location = new System.Drawing.Point(15, 55);
            txtInputText.Size = new System.Drawing.Size(510, 60);
            txtInputText.Multiline = true;
            txtInputText.PlaceholderText = "请输入待分词的文本";

            // 分词按钮
            btnSegment = new Button();
            btnSegment.Text = "分词";
            btnSegment.Location = new System.Drawing.Point(15, 125);
            btnSegment.Size = new System.Drawing.Size(100, 30);
            btnSegment.Click += BtnSegment_Click;

            // 结果标签和文本框
            lblResult = new Label();
            lblResult.Text = "分词结果:";
            lblResult.Location = new System.Drawing.Point(15, 165);
            lblResult.Size = new System.Drawing.Size(60, 20);

            txtResult = new TextBox();
            txtResult.Location = new System.Drawing.Point(15, 190);
            txtResult.Size = new System.Drawing.Size(510, 40);
            txtResult.Multiline = true;
            txtResult.ReadOnly = true;

            // 添加到分组
            grpSegment.Controls.Add(lblInput);
            grpSegment.Controls.Add(txtInputText);
            grpSegment.Controls.Add(btnSegment);
            grpSegment.Controls.Add(lblResult);
            grpSegment.Controls.Add(txtResult);

            // 添加到主窗口
            this.Controls.Add(grpRemoveDup);
            this.Controls.Add(grpSegment);
        }

        private void BtnRemoveDup_Click(object sender, EventArgs e)
        {
            string sourceDir = txtSourceDir.Text.Trim();
            string targetDir = txtTargetDir.Text.Trim();

            if (string.IsNullOrEmpty(sourceDir))
            {
                MessageBox.Show("请输入源文件夹路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(targetDir))
            {
                MessageBox.Show("请输入目标文件夹路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                new ImpReplace().BatchRemoveDup(sourceDir, targetDir);
                MessageBox.Show("批量去重完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new ImpLog().Log(["去重异常", "错误信息:" + ex.Message, "异常类型:" + ex.GetType().Name]);
                MessageBox.Show("去重失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSegment_Click(object sender, EventArgs e)
        {
            string text = txtInputText.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("请输入待分词的文本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string[] words = new ImpJieba().Cut(text);
                txtResult.Text = string.Join("\t", words);
            }
            catch (Exception ex)
            {
                new ImpLog().Log(["UI分词异常", "错误信息:" + ex.Message, "异常类型:" + ex.GetType().Name]);
                MessageBox.Show("分词失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
