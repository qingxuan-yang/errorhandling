pipeline{
    parameters{
        string(
            name: "DOCKER_REGISTRY",
            defaultValue:"192.168.1.10:30000",
            description:"docker registry ip:port"
        )

        string(
            name: "GITLAB_CONNECTION",
            defaultValue:"gitlab-system",
            description:"helloworld"
        )

        string(
            name: "ERROR_HANDLING_VERSION",
            defaultValue: "dev",
            description:"error handling version"
        )

        string(
            name: "DEPLOYMENT_AGENT",
            defaultValue: "TacDynamics-acer-agent",
            description: "Deployment Agent"
        )

        string(
            name: "COMMAND",
            defaultValue: "start",
            description: "Deployment Command"
        )

        string(
        name: "DOCKER_COMPOSE_FILE",
        defaultValue:"docker-compose.yml",
        description:"Compose File Name"
    )

    }

    options{
      gitLabConnection("${params.GITLAB_CONNECTION}")
    }

    agent{
        label "TacDynamics-acer-agent"
    }

    stages {
      stage('Build ErrorHandlingService'){
        steps{
            echo "start build ErrorhandlingService"
              sh "sg docker -c 'docker-compose -f docker-compose.yml build'"
        }
      }

    }

    post{
        success {
            updateGitlabCommitStatus name:'build', state:'success'
            sh "sg docker -c 'docker tag errorhandling ${params.DOCKER_REGISTRY}/errorhandling:${params.ERROR_HANDLING_VERSION}'"
            sh "sg docker -c 'docker push ${params.DOCKER_REGISTRY}/errorhandling:${params.ERROR_HANDLING_VERSION}'"

        }
        failure{
            echo "Failed, bypass pushing images..."
            updateGitlabCommitStatus name:'build', state:'failed'
        }
    }

}