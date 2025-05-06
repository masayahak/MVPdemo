namespace MVPdemo
{
    public interface IView利用者
    {
        // 列
        string ID { get; set; }
        string 利用者名 { get; set; }
        string 住所 { get; set; }
        string 誕生日 { get; set; }
        int Version { get; set; }

        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // イベント
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // メソッド
        void Set利用者ListBindingSource(BindingSource 利用者list);
        void Show();
    }

    public partial class 利用者View : Form, IView利用者
    {
        private bool _isEdit;
        private bool _isSuccessful;
        private string _message = string.Empty;

        public 利用者View()
        {
            InitializeComponent();

            AssociateAndRaiseViewEvents();
        }

        // -------------------------------------------------
        // プロパティ
        // -------------------------------------------------
        public string ID
        {
            get => TextBoxID.Text;
            set => TextBoxID.Text = value;
        }

        public string 利用者名
        {
            get => TextBox利用者名.Text;
            set => TextBox利用者名.Text = value;
        }
        public string 住所
        {
            get => TextBox住所.Text;
            set => TextBox住所.Text = value;
        }
        public string 誕生日
        {
            get => TextBox誕生日.Text;
            set => TextBox誕生日.Text = value;
        }

        private int _version = 0;
        public int Version
        {
            get => _version;
            set => _version = value;
        }

        public bool IsEdit
        {
            get { return _isEdit; }
            set { _isEdit = value; }
        }

        public bool IsSuccessful
        {
            get { return _isSuccessful; }
            set { _isSuccessful = value; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                ShowMessageToUser(value);
            }
        }

        // -------------------------------------------------
        // データ操作イベント（Presenterで実装）
        // -------------------------------------------------
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? SaveEvent;
        public event EventHandler? CancelEvent;

        private void AssociateAndRaiseViewEvents()
        {
            // 登録系 -----------------------------------------
            // 追加
            this.Button追加.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                Panel操作.Visible = true;
                this.Button削除.Visible = false;
            };

            // 修正
            this.DataGridView.CellDoubleClick += (s, e) =>
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                Panel操作.Visible = true;
                this.Button削除.Visible = true;
            };

            this.Button保存.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (IsSuccessful)
                {
                    Panel操作.Visible = false;
                }
            };

            this.Buttonキャンセル.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                Panel操作.Visible = false;
            };
            this.Button削除.Click += delegate
            {
                var result = MessageBox.Show("削除します。", "警告",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    Panel操作.Visible = false;
                }
            };

            // 初期表示は編集部を隠す
            Panel操作.Visible = false;
        }

        // メッセージ表示
        private void ShowMessageToUser(string message)
        {
            this._message = message;
            MessageBox.Show(this._message);
        }

        // -------------------------------------------------
        // GridViewの設定
        // -------------------------------------------------
        public void Set利用者ListBindingSource(BindingSource 利用者list)
        {
            DataGridView設定();
            this.DataGridView.DataSource = 利用者list;
        }

        private void DataGridView設定()
        {
            DataGridView.Columns.Clear();

            // 各列を定義して追加する
            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "利用者名",
                HeaderText = "利用者名",
                Width = 100
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "住所",
                HeaderText = "住所",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "誕生日",
                HeaderText = "誕生日",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "yyyy/MM/dd"
                }
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Version",
                HeaderText = "Version",
                Visible = false
            });

        }

    }
}
