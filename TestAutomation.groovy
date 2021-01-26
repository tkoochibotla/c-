node {
   stage('Preparation') { // for display purposes
        // Get some code from a GitHub repository
        git branch: 'master', url: 'https://github.com/tkoochibotla/c-.git'
    }
   stage('Test') { // for display purposes
        // Get some code from a GitHub repository
       bat 'dotnet test'
    }
   
     }
 
