namespace Delegates_UseCase.Lib
{
    //Dieses Delegate wird bereitgestellt, damit der Kunde in seinem Programm mitbekommt, welche Ereignisse gerade in der Library passieren 
    public delegate void InstallProcessMessage(string msg);

    public class DeploymentProcess
    {

        public bool DependenciesPackagesCheck(InstallProcessMessage installProcessMessage)
        {

           
            installProcessMessage("Dependency checking...");

            Thread.Sleep(1000);


            installProcessMessage("Dependency checking...[finish]");


            int number = new Random().Next(10);


            bool retVal = false;

            if (number % 2 == 0)
            {
                retVal = true;
                installProcessMessage("Dependency is found....");
            }
                
            else
            {
                retVal = false;
                installProcessMessage("Dependency isnt found....");
            }
                

            return retVal; //true wird einfach simuliert, dass es Dependencies gibt 

        }

        public void InstallDependencyPackage(InstallProcessMessage installProcessMessage)
        {

            
            installProcessMessage("Dependency Installation...");

            Thread.Sleep(1000);


            installProcessMessage("Dependency Installation...[finish]");
        }

        public void InstallDependencyPackageB(Action<string> installProcessMessage)
        {


            installProcessMessage("Dependency Installation...");

            Thread.Sleep(1000);


            installProcessMessage("Dependency Installation...[finish]");
        }

        public void InstallCurrentPackage(InstallProcessMessage installProcessMessage)
        {
            installProcessMessage("Package Installation...");

            Thread.Sleep(3000);


            installProcessMessage("Package Installation...[finish]");
        }
    }
}