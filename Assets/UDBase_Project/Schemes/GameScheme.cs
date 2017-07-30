#if Scheme_GameScheme
using UDBase.Common;
using UDBase.Controllers.EventSystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddController<Events>(new EventController());
	}
}
#endif
