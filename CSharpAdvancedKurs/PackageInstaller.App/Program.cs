using static PackageInstaller.PackageInstallerB;

namespace PackageInstaller.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region PackageInstaller Version 1.0 -> event delegates Beispiel
            PackageInstaller packageInstaller = new PackageInstaller();

            packageInstaller.InstallProcessMessageDelegate += PackageInstaller_UIOutput;
            bool hasFoundDependencies = packageInstaller.CheckDependencies();

            if (hasFoundDependencies)
                packageInstaller.InstallDependencies();


            packageInstaller.InstallPackage();

            #endregion


            #region PackageInstaller Version 2.0 EventHandler 
            PackageInstallerB packageInstallerB = new PackageInstallerB();

            packageInstallerB.SendMessageDelegate += PackageInstallerB_SendMessageDelegate;
            packageInstallerB.SendMessageDelegateB += PackageInstallerB_SendMessageDelegateB;
            #endregion
        }

        private static void PackageInstallerB_SendMessageDelegateB(object? sender, PackageInstallerEventArg e)
        {
            Console.WriteLine(e.Message);
        }

        private static void PackageInstallerB_SendMessageDelegate(object? sender, EventArgs e)
        {
            PackageInstallerEventArg packageInstallerEvent = (PackageInstallerEventArg)e;
            Console.WriteLine(packageInstallerEvent.Message);

        }

        private static void PackageInstaller_UIOutput(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}