using Moq;
using MVPdemo.Models;
using MVPdemo.Presenters;
using MVPdemo.Repositories;
using MVPdemo.Views;
using System.Reflection;
using System.Windows.Forms;

namespace MVPdemo.Test
{
    [TestClass]
    public class 利用者PresenterTests
    {
        [TestMethod]
        public void LoadAll利用者_初期表示で全件取得される()
        {
            var mockView = new Mock<I利用者View>();
            var mockRepo = new Mock<I利用者Repository>();

            // --------------------------------------------------------------------
            // 単体テストの基本的な考え方：
            //     実際のDBの値に依存しないように、モックを使ってテストする。
            //     （ ここでモックが返す値を定義している ）
            // --------------------------------------------------------------------
            var 利用者一覧 = new List<利用者Model>
            {
                new 利用者Model { ID = 1, 利用者名 = "山田太郎", Version = 1 },
                new 利用者Model { ID = 2, 利用者名 = "鈴木花子", Version = 1 }
            };

            mockRepo.Setup(r => r.GetAll()).Returns(利用者一覧);

            BindingSource? capturedBindingSource = null;
            mockView.Setup(v => v.Set利用者ListBindingSource(It.IsAny<BindingSource>()))
                    .Callback<BindingSource>(bs => capturedBindingSource = bs);

            mockView.Setup(v => v.Show());

            // Act
            var presenter = new 利用者Presenter(mockView.Object, mockRepo.Object);

            // Assert
            Assert.IsNotNull(capturedBindingSource);
            var bs = capturedBindingSource;

            // 件数の確認
            Assert.AreEqual(2, bs.Count);
            // 1件目の利用者名の確認
            Assert.AreEqual("山田太郎", ((利用者Model)bs[0]!).利用者名);
        }

        [TestMethod]
        public void AddNew利用者_追加操作で初期化される()
        {
            var mockView = new Mock<I利用者View>();
            var mockRepo = new Mock<I利用者Repository>();

            mockView.Setup(v => v.Set利用者ListBindingSource(It.IsAny<BindingSource>()));
            mockView.Setup(v => v.Show());

            var presenter = new 利用者Presenter(mockView.Object, mockRepo.Object);

            mockView.Raise(v => v.AddNewEvent += null!, EventArgs.Empty);

            mockView.VerifySet(v => v.IsEdit = false);
            mockView.VerifySet(v => v.ID = "0");
            mockView.VerifySet(v => v.利用者名 = "");
            mockView.VerifySet(v => v.住所 = "");
            mockView.VerifySet(v => v.誕生日 = "");
            mockView.VerifySet(v => v.Version = 0);
        }

        [TestMethod]
        public void Save利用者_新規登録に成功すると成功メッセージが設定される()
        {
            var mockView = new Mock<I利用者View>();
            var mockRepo = new Mock<I利用者Repository>();

            // Viewから入力されたデータ
            mockView.Setup(v => v.IsEdit).Returns(false);
            mockView.Setup(v => v.ID).Returns("0");
            mockView.Setup(v => v.利用者名).Returns("新規さん");
            mockView.Setup(v => v.住所).Returns("テスト県");
            mockView.Setup(v => v.誕生日).Returns("2000/01/01");
            mockView.Setup(v => v.Version).Returns(0);

            mockRepo.Setup(r => r.Add(It.IsAny<利用者Model>())).Returns(true);

            mockView.Setup(v => v.Set利用者ListBindingSource(It.IsAny<BindingSource>()));
            mockView.Setup(v => v.Show());

            var presenter = new 利用者Presenter(mockView.Object, mockRepo.Object);

            mockView.Raise(v => v.SaveEvent += null!, EventArgs.Empty);

            mockView.VerifySet(v => v.IsSuccessful = true);
            mockView.VerifySet(v => v.Message = "利用者情報を登録しました。");
        }

        [TestMethod]
        public void Save利用者_修正に成功すると成功メッセージが設定される()
        {
            var mockView = new Mock<I利用者View>();
            var mockRepo = new Mock<I利用者Repository>();

            mockView.Setup(v => v.IsEdit).Returns(true);
            mockView.Setup(v => v.ID).Returns("1");
            mockView.Setup(v => v.利用者名).Returns("編集後さん");
            mockView.Setup(v => v.住所).Returns("編集県");
            mockView.Setup(v => v.誕生日).Returns("1999/12/31");
            mockView.Setup(v => v.Version).Returns(1);

            mockRepo.Setup(r => r.Edit(It.IsAny<利用者Model>())).Returns(true);

            mockView.Setup(v => v.Set利用者ListBindingSource(It.IsAny<BindingSource>()));
            mockView.Setup(v => v.Show());

            var presenter = new 利用者Presenter(mockView.Object, mockRepo.Object);

            mockView.Raise(v => v.SaveEvent += null!, EventArgs.Empty);

            mockView.VerifySet(v => v.IsSuccessful = true);
            mockView.VerifySet(v => v.Message = "利用者情報を修正しました。");
        }

        [TestMethod]
        public void Delete利用者_削除成功で成功メッセージが設定される()
        {
            var mockView = new Mock<I利用者View>();
            var mockRepo = new Mock<I利用者Repository>();

            var dummyUser = new 利用者Model { ID = 10, 利用者名 = "削除対象", Version = 1 };

            mockView.Setup(v => v.Set利用者ListBindingSource(It.IsAny<BindingSource>()));
            mockView.Setup(v => v.Show());
            mockRepo.Setup(r => r.Delete(It.IsAny<利用者Model>())).Returns(true);

            var presenter = new 利用者Presenter(mockView.Object, mockRepo.Object);

            // 内部の _bindingSource利用者 に Current をセットする
            var field = typeof(利用者Presenter).GetField("_bindingSource利用者", BindingFlags.NonPublic | BindingFlags.Instance);
            var bs = (BindingSource?)field?.GetValue(presenter);
            bs!.DataSource = new List<利用者Model> { dummyUser };
            bs.Position = 0;

            mockView.Raise(v => v.DeleteEvent += null!, EventArgs.Empty);

            mockView.VerifySet(v => v.IsSuccessful = true);
            mockView.VerifySet(v => v.Message = "利用者情報を削除しました。");
        }
    }
}
