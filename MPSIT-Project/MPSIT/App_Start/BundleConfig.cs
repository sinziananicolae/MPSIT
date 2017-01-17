using System.Web;
using System.Web.Optimization;

namespace MPSIT
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region AngularJS
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/Core/AngularJS/angular.min.js",
                      "~/Scripts/Core/AngularJS/angular-animate.min.js",
                      "~/Scripts/Core/AngularJS/angular-cookies.min.js",
                      "~/Scripts/Core/AngularJS/angular-resource.min.js",
                      "~/Scripts/Core/AngularJS/angular-route.min.js",
                      "~/Scripts/Core/AngularJS/angular-sanitize.min.js",
                      "~/Scripts/Core/AngularJS/angular-simple-logger.min.js",
                      "~/Scripts/Core/AngularJS/angular-loader.min.js",
                      "~/Scripts/Core/AngularJS/angular-google-maps.js",
                      "~/Scripts/Core/AngularJS/angular-chart.js"));
            #endregion

            #region Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Core/Bootstrap/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-css").Include(
                      "~/Content/Bootstrap/css/bootstrap.min.css",
                      "~/Content/Bootstrap/css/bootstrap-theme.min.css"));
            #endregion

            #region Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-ui").Include(
                      "~/Scripts/Core/Bootstrap/ui-bootstrap-tpls-2.4.0.min.js"));
            #endregion

            #region FontAwesome
            bundles.Add(new StyleBundle("~/Content/font-awesome-css").Include(
                      "~/Content/FontAwesome/css/font-awesome.min.css"));
            #endregion

            #region Moment
            bundles.Add(new ScriptBundle("~/bundles/momentjs").Include(
                        "~/Scripts/Core/Moment/moment.js"));
            #endregion

            #region JQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Core/JQuery/jquery-1.12.3.min.js"));
            #endregion

            #region ChartJs
            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                        "~/Scripts/Core/Chartjs/Chart.min.js"));
            #endregion

            #region JQuery-UI
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/Core/JQuery/jquery-ui.min.js"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui-css").Include(
                     "~/Content/JQuery-UI/jquery-ui.min.css",
                     "~/Content/JQuery-UI/jquery-ui.theme.min.css"));
            #endregion

            #region Toastr
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/Core/Toastr/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/toastr-css").Include(
                      "~/Content/Toastr/toastr.css"));
            #endregion

            #region Underscore
            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                     "~/Scripts/Core/Underscore/underscore.min.js"));
            #endregion

            #region Lodash
            bundles.Add(new ScriptBundle("~/bundles/lodash").Include(
                     "~/Scripts/Core/Lodash/lodash.js"));
            #endregion

            #region Theme
            bundles.Add(new StyleBundle("~/Content/theme-css").Include(
                     "~/Content/Theme/AdminLTE.min.css",
                     "~/Content/Theme/skins/skin-green.css"));
            #endregion

            #region Application
            bundles.Add(new StyleBundle("~/Content/app-css").Include(
                     "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/Application/app.js",
                    "~/Scripts/Core/Theme/custom.js",
                    "~/Scripts/Application/services.js",
                    "~/Scripts/Application/Home/HomeController.js",
                    "~/Scripts/Application/Apiary/ApiaryController.js",
                    "~/Scripts/Application/HiveFile/HiveFileController.js",
                    "~/Scripts/Application/Map/MapController.js"
                     ));
            #endregion
        }
    }
}
