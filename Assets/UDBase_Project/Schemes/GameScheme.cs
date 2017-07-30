#if Scheme_GameScheme
using UDBase.Common;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.UserSystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddController<Log>(new UnityLog());
		
		var save = new FsJsonDataSave().AddNode<UserSaveNode>("user");
		AddController<Save>(save);
		
		AddController<Scene>(new DirectSceneLoader());
		AddController<User>(new SaveUser());
		AddController<Events>(new EventController());
		AddController<UDBase.Controllers.LeaderboardSystem.Leaderboard>(
			new WebLeaderboard("https://konhit.xyz/lbservice/", "ld39", "1.0.0", "ld39_user", "ld39_password"));
	}
}
#endif
