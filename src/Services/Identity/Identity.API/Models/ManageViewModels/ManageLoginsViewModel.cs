namespace Identity.API.Models.ManageViewModels
{
    using Microsoft.AspNetCore.Http.Authentication;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
