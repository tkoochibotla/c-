def nuggetPath = '"C:/Users/Koochibotla.Kumar/Downloads/nuget.exe"'
def nunitPath = '"packages/NUnit.ConsoleRunner.3.8.0/tools/nunit3-console.exe"'
def basePath = "automationframework/TestAutomation"
def buildConfig = CONFIG // read build configuration from job parameter 'CONFIG'
node {
    stage("scm") {
        git branch: 'master', url: 'https://github.com/tkoochibotla/c-.git'    }
    stage("build") {
        dir(basePath) {
            bat "${nuggetPath} restore TestAutomation.sln"
            bat "MSBuild.exe TestAutomation.sln /t:Clean;Build /p:Configuration=${buildConfig}" 
        }
    }
    stage("run tests") {
        def executeTestCmd = "${nunitPath} Features/bin/${buildConfig}/Features.dll"
        dir(basePath) {
            bat(script: "${executeTestCmd}", returnStatus: true)
        }
    }
    }
