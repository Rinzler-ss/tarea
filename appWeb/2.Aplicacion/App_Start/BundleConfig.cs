using System.Web;
using System.Web.Optimization;

namespace appWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/1.UserInterface/Web/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/1.UserInterface/Web/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/1.UserInterface/Web/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/1.UserInterface/Web/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/1.UserInterface/Web/Content/css").Include(
                      "~/1.UserInterface/Web/Content/bootstrap.css",
                      "~/1.UserInterface/Web/Content/site.css"));
        }
    }
}
