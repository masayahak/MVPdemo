namespace MVPdemo
{
    public interface IView���p��
    {
        // ��
        string ID { get; set; }
        string ���p�Җ� { get; set; }
        string �Z�� { get; set; }
        string �a���� { get; set; }
        int Version { get; set; }

        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // �C�x���g
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // ���\�b�h
        void Set���p��ListBindingSource(BindingSource ���p��list);
        void Show();
    }

    public partial class ���p��View : Form, IView���p��
    {
        private bool _isEdit;
        private bool _isSuccessful;
        private string _message = string.Empty;

        public ���p��View()
        {
            InitializeComponent();

            AssociateAndRaiseViewEvents();
        }

        // -------------------------------------------------
        // �v���p�e�B
        // -------------------------------------------------
        public string ID
        {
            get => TextBoxID.Text;
            set => TextBoxID.Text = value;
        }

        public string ���p�Җ�
        {
            get => TextBox���p�Җ�.Text;
            set => TextBox���p�Җ�.Text = value;
        }
        public string �Z��
        {
            get => TextBox�Z��.Text;
            set => TextBox�Z��.Text = value;
        }
        public string �a����
        {
            get => TextBox�a����.Text;
            set => TextBox�a����.Text = value;
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
        // �f�[�^����C�x���g�iPresenter�Ŏ����j
        // -------------------------------------------------
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? SaveEvent;
        public event EventHandler? CancelEvent;

        private void AssociateAndRaiseViewEvents()
        {
            // �o�^�n -----------------------------------------
            // �ǉ�
            this.Button�ǉ�.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                Panel����.Visible = true;
                this.Button�폜.Visible = false;
            };

            // �C��
            this.DataGridView.CellDoubleClick += (s, e) =>
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                Panel����.Visible = true;
                this.Button�폜.Visible = true;
            };

            this.Button�ۑ�.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (IsSuccessful)
                {
                    Panel����.Visible = false;
                }
            };

            this.Button�L�����Z��.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                Panel����.Visible = false;
            };
            this.Button�폜.Click += delegate
            {
                var result = MessageBox.Show("�폜���܂��B", "�x��",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    Panel����.Visible = false;
                }
            };

            // �����\���͕ҏW�����B��
            Panel����.Visible = false;
        }

        // ���b�Z�[�W�\��
        private void ShowMessageToUser(string message)
        {
            this._message = message;
            MessageBox.Show(this._message);
        }

        // -------------------------------------------------
        // GridView�̐ݒ�
        // -------------------------------------------------
        public void Set���p��ListBindingSource(BindingSource ���p��list)
        {
            DataGridView�ݒ�();
            this.DataGridView.DataSource = ���p��list;
        }

        private void DataGridView�ݒ�()
        {
            DataGridView.Columns.Clear();

            // �e����`���Ēǉ�����
            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "���p�Җ�",
                HeaderText = "���p�Җ�",
                Width = 100
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "�Z��",
                HeaderText = "�Z��",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "�a����",
                HeaderText = "�a����",
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
