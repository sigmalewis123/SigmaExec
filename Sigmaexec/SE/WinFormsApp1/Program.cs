using System;
using System.Drawing;
using System.Windows.Forms;
using QuorumAPI;

public class SigmaExec : Form
{
    private Button attachButton, executeButton, killButton, checkStateButton, autoAttachButton;
    private TextBox scriptInput;
    private Label scriptLabel;

    public SigmaExec()
    {
        this.Text = "Sigma Exec";
        this.Size = new Size(500, 400);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        attachButton = new Button { Text = "Attach", Left = 20, Top = 20, Width = 120, Height = 40 };
        attachButton.Click += (sender, e) => QuorumAPI.QuorumAPI.AttachAPI();

        executeButton = new Button { Text = "Execute", Left = 20, Top = 70, Width = 120, Height = 40 };
        executeButton.Click += (sender, e) => QuorumAPI.QuorumAPI.ExecuteScript(scriptInput.Text);

        killButton = new Button { Text = "Kill Roblox", Left = 20, Top = 120, Width = 120, Height = 40 };
        killButton.Click += (sender, e) => QuorumAPI.QuorumAPI.KillRoblox();

        checkStateButton = new Button { Text = "Check State", Left = 20, Top = 170, Width = 120, Height = 40 };
        checkStateButton.Click += (sender, e) =>
        {
            int result = QuorumAPI.QuorumAPI.GetAttachState();
            MessageBox.Show(result == 1 ? "SE attached." : "SE not attached.", "Attach Status");
        };

        autoAttachButton = new Button { Text = "Auto Attach", Left = 20, Top = 220, Width = 120, Height = 40 };
        autoAttachButton.Click += (sender, e) => QuorumAPI.QuorumAPI.SetAutoInject(true);

        scriptLabel = new Label { Text = "Script Input:", Left = 160, Top = 20, Width = 100 };

        scriptInput = new TextBox { Left = 160, Top = 50, Width = 300, Height = 250, Multiline = true, ScrollBars = ScrollBars.Vertical };

        this.Controls.Add(attachButton);
        this.Controls.Add(executeButton);
        this.Controls.Add(killButton);
        this.Controls.Add(checkStateButton);
        this.Controls.Add(autoAttachButton);
        this.Controls.Add(scriptLabel);
        this.Controls.Add(scriptInput);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SigmaExec());
    }
}

