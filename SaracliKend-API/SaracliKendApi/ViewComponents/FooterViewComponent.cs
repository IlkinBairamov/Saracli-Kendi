using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IFooterService _footerService;

        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerInfo = await _footerService.GetFooterAsync();
            return View(footerInfo);
        }
    }
}
