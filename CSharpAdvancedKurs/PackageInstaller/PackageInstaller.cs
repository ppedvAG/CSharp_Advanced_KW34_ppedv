namespace PackageInstaller
{

    public delegate void InstallProcessMessage(string msg);

    public class PackageInstaller
    {
        //Wie bieten optional unsere Delegates an
        public event InstallProcessMessage InstallProcessMessageDelegate;



        public PackageInstaller()
        {

        }

        public bool CheckDependencies ()
        {

            //aus diesem Statement.....
            //if (InstallProcessMessageDelegate != null)
            //    InstallProcessMessageDelegate("Dependency checking...");


            //... wird dieses Statement
            OnInstallProcessMessage("Dependency checking...");

            Thread.Sleep(1000);


            OnInstallProcessMessage("Dependency checking...[finish]");


            int number = new Random().Next(10);


            bool retVal = false;

            if (number % 2 == 0)
            {
                retVal = true;
                OnInstallProcessMessage("Dependency is found....");
            }

            else
            {
                retVal = false;
                OnInstallProcessMessage("Dependency isnt found....");
            }


            return retVal; //true wird einfach simuliert, dass es Dependencies gibt 
        }

        public void InstallDependencies()
        {
            OnInstallProcessMessage("Dependency Installation...");

            Thread.Sleep(1000);


            OnInstallProcessMessage("Dependency Installation...[finish]");
        }


        public void InstallPackage()
        {
            OnInstallProcessMessage("Package Installation...");

            Thread.Sleep(3000);


            OnInstallProcessMessage("Package Installation...[finish]");
        }

        protected virtual void OnInstallProcessMessage(string msg)
            => InstallProcessMessageDelegate?.Invoke(msg); //Wenn InstallProcessMessageDelegate ungleich NULL ist, wird Invoke ausgeführt 
    }
}