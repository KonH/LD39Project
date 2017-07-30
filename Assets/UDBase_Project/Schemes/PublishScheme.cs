#if Scheme_PublishScheme
using UDBase.Common;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.UserSystem;
using UDBase_Project.Scripts.Logics;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		var save = new FsJsonDataSave().
			AddNode<UserSaveNode>("user").
			AddNode<GameState>("state");
		AddController<Save>(save);
		
		AddController<Scene>(new DirectSceneLoader());
		AddController<User>(new SaveUser());
		AddController<Events>(new EventController());
		AddController<UDBase.Controllers.LeaderboardSystem.Leaderboard>(
			new WebLeaderboard("https://konhit.xyz/lbservice/", "ld39", "1.0.0", "ld39_user", "ld39_password"));
	}
}
#endif
