using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksAndAuthors.Startup))]
namespace BooksAndAuthors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
