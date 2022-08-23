using Delegates_UseCase.Lib;

namespace Delegates_UseCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstallProcessMessage tellmeWhatIsHappenDelegate = new InstallProcessMessage(OutputUI);

            DeploymentProcess deploymentProcess = new DeploymentProcess();

            bool findDependencies = deploymentProcess.DependenciesPackagesCheck(tellmeWhatIsHappenDelegate);

            if (findDependencies)
                deploymentProcess.InstallDependencyPackage(tellmeWhatIsHappenDelegate);

            deploymentProcess.InstallCurrentPackage(tellmeWhatIsHappenDelegate);




            #region Action sind sogar die bessere Wahl und werden genauso verwenden, wie delagate
            Action<string> action = new Action<string>(OutputUI);
            deploymentProcess.InstallDependencyPackageB(action);
            deploymentProcess.InstallDependencyPackageB(OutputUI);

            
            #endregion
        }

        static public void OutputUI (string msg)
            => Console.WriteLine(msg);
    }



    
    
}