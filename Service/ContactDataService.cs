using NopBrasil.Plugin.Widgets.ContactData.Models;

namespace NopBrasil.Plugin.Widgets.ContactData.Service
{
    public class ContactDataService : IContactDataService
    {
        private readonly ContactDataSettings _contactDataSettings;

        public ContactDataService(ContactDataSettings contactDataSettings)
        {
            this._contactDataSettings = contactDataSettings;
        }

        public PublicInfoModel GetModel()
        {
            PublicInfoModel model = new PublicInfoModel();
            model.Html = "NopCommerce Brasil";
            return model;
        }
    }
}
