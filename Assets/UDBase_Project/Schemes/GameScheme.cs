#if Scheme_GameScheme
using UDBase.Common;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.UserSystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddController<Log>(new UnityLog());
		
		var save = new FsJsonDataSave().AddNode<UserSaveNode>("user");
		AddController<Save>(save);
		
		AddController<User>(new SaveUser());
		AddController<Events>(new EventController());
	}
}
#endif
