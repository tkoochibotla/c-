node {
    stage("scm") {
        git branch: 'master', url: 'https://github.com/tkoochibotla/c-.git'    }
    stage("build") {
        dir(basePath) {
            bat "${nuggetPath} restore TestAutomation.sln"
            bat "MSBuild.exe TestAutomation.sln /t:Clean;Build /p:Configuration=Dev_Env" 
        }
    }
    stage("run tests") {
        def executeTestCmd = "${nunitPath} Features/bin/${buildConfig}/Features.dll"
        dir(basePath) {
            bat(script: "${executeTestCmd}", returnStatus: true)
        }
    }
    }
