using MVPdemo.Models;
using MVPdemo.Views;
using MVPdemo.Repositories;

namespace MVPdemo.Presenters
{
    public class 利用者Presenter
    {
        //Fields
        private readonly I利用者View _view;
        private readonly I利用者Repository _repository;
        private readonly BindingSource _bindingSource利用者;
        private IEnumerable<利用者Model> _利用者List;

        //コンストラクタ
        public 利用者Presenter(I利用者View view, I利用者Repository repository)
        {
            this._bindingSource利用者 = new BindingSource();
            this._view = view;
            this._repository = repository;
            this._view.AddNewEvent += AddNew利用者;
            this._view.EditEvent += LoadSelected利用者ToEdit;
            this._view.DeleteEvent += Delete利用者;
            this._view.SaveEvent += Save利用者;
            this._view.CancelEvent += Cancel利用者;

            this._view.Set利用者ListBindingSource(_bindingSource利用者);

            _利用者List = [];
            LoadAll利用者();

            this._view.Show();
        }

        private void LoadAll利用者()
        {
            _利用者List = _repository.GetAll();
            _bindingSource利用者.DataSource = _利用者List;
        }

        private void AddNew利用者(object? sender, EventArgs e)
        {
            // 追加時の初期値
            _view.IsEdit = false;

            CleanViewFields();
        }

        private void LoadSelected利用者ToEdit(object? sender, EventArgs e)
        {
            if (_bindingSource利用者.Current is not 利用者Model) return;

            var current = (利用者Model)_bindingSource利用者.Current;
            _view.ID = current.ID.ToString();
            _view.利用者名 = current.利用者名;
            _view.住所 = current.住所 ?? string.Empty;
            _view.誕生日 = current.誕生日.ToString("yyyy/MM/dd");
            _view.Version = current.Version;

            _view.IsEdit = true;
        }

        // 型変換チェック
        private bool CanConvertTo()
        {
            if (!int.TryParse(_view.ID, out _))
            {
                _view.Message = "IDは整数で入力してください。";
                return false;
            }
            if (!DateTime.TryParse(_view.誕生日, out _))
            {
                _view.Message = "誕生日は日付を入力してください。";
                return false;
            }

            return true;
        }


        private void Save利用者(object? sender, EventArgs e)
        {
            if (!CanConvertTo())
            {
                _view.IsSuccessful = false;
                return;
            }

            var model = new 利用者Model();
            model.ID = int.Parse(_view.ID);
            model.利用者名 = _view.利用者名;
            model.住所 = _view.住所;
            model.誕生日 = DateTime.Parse(_view.誕生日);
            model.Version = _view.Version;

            if (_view.IsEdit)
            {
                bool ret = _repository.Edit(model);
                if (ret)
                {
                    _view.IsSuccessful = true;
                    _view.Message = "利用者情報を修正しました。";
                }
                else
                {
                    _view.IsSuccessful = false;
                    _view.Message = "他のユーザーによって同じデータが更新されています。\nこの修正をキャンセルして、もう一度初めから修正してください。";
                }
            }
            else
            {
                bool ret = _repository.Add(model);
                if (ret)
                {
                    _view.IsSuccessful = true;
                    _view.Message = "利用者情報を登録しました。";
                }
                else
                {
                    _view.IsSuccessful = false;
                    _view.Message = "利用者情報の登録に失敗しました。";
                }
            }

            LoadAll利用者();

            if (_view.IsSuccessful)
            {
                CleanViewFields();
            }
        }

        private void CleanViewFields()
        {
            _view.ID = "0";
            _view.利用者名 = string.Empty;
            _view.住所 = string.Empty;
            _view.誕生日 = string.Empty;
            _view.Version = 0;
        }

        private void Cancel利用者(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void Delete利用者(object? sender, EventArgs e)
        {
            if (_bindingSource利用者.Current is not 利用者Model current) return;

            bool ret = _repository.Delete(current);
            if (ret)
            {
                _view.IsSuccessful = true;
                _view.Message = "利用者情報を削除しました。";
            }
            else
            {
                _view.IsSuccessful = false;
                _view.Message = "他のユーザーによって同じデータが更新されています。\nもう一度初めから削除してください。";
            }
            LoadAll利用者();
        }
    }
}
