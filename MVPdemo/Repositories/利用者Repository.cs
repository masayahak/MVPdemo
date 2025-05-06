using MVPdemo.Models;
using System.ComponentModel;

namespace MVPdemo.Repositories
{
    public interface I利用者Repository
    {
        IEnumerable<利用者Model> GetAll();
        IEnumerable<利用者Model> GetBySearch(string SearchKey);
        bool Add(利用者Model user);
        bool Edit(利用者Model user);
        bool Delete(利用者Model user);
    }

    public class 利用者Repository : I利用者Repository
    {
        private BindingList<利用者Model> _users = new();

        public 利用者Repository()
        {
            // 初期データ
            _users.Add(new 利用者Model { ID = 1, 利用者名 = "山田太郎", 住所 = "東京都", 誕生日 = new DateTime(1990, 1, 1), Version = 1 });
            _users.Add(new 利用者Model { ID = 2, 利用者名 = "鈴木花子", 住所 = "大阪府", 誕生日 = new DateTime(1995, 5, 5), Version = 1 });
            _users.Add(new 利用者Model { ID = 3, 利用者名 = "佐藤次郎", 住所 = "北海道", 誕生日 = new DateTime(1988, 8, 8), Version = 1 });
        }

        // ユーザー一覧を取得
        public IEnumerable<利用者Model> GetAll() => _users;

        // IDや名称でユーザー一覧を取得
        public IEnumerable<利用者Model> GetBySearch(string SearchKey)
        {
            if (string.IsNullOrEmpty(SearchKey))
                return _users;
            return _users.Where(u => u.ID.ToString().Contains(SearchKey) || u.利用者名.Contains(SearchKey));
        }

        // 追加
        public bool Add(利用者Model user)
        {
            // 新しいIDを設定
            int MaxID = _users.Max(u => u.ID);
            user.ID = MaxID + 1;

            _users.Add(user);
            return true;
        }

        // 修正
        public bool Edit(利用者Model user)
        {
            // IDとバージョンで一致するユーザーを検索
            var index = _users.ToList().FindIndex(u => u.ID == user.ID  && u.Version == user.Version);

            // 一致するユーザーが見つからない場合は、修正できない（楽観的排他ロック失敗）
            if (index < 0) return false;

            // バージョンをインクリメント    
            user.Version += 1; 
            _users[index] = user;
            return true;
        }

        // 削除
        public bool Delete(利用者Model user)
        {
            var userForDelete = _users.FirstOrDefault(u => u.ID == user.ID && u.Version == user.Version);

            // 一致するユーザーが見つからない場合は、修正できない（楽観的排他ロック失敗）
            if (userForDelete == null) return false;

            _users.Remove(userForDelete);
            return true;
        }
    }
}
