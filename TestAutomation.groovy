node {
  stage('HelloWorld') {
    echo 'Hello World'
  }

  stage('git clone') {
    git clone "https://github.com/tkoochibotla/c-.git"
  }
}
