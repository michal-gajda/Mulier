sln = Mulier.sln
token = TOKEN
sonarqube = http://sonarqube.gajda.co.uk/

all:
	dotnet sonarscanner begin /k:"Mulier" /d:sonar.token="$(token)" /d:sonar.host.url="$(sonarqube)" /d:sonar.cs.vscoveragexml.reportsPaths="coverage.xml"
	dotnet build --no-incremental
	dotnet-coverage collect "dotnet test" --output-format xml --output "coverage.xml"
	dotnet sonarscanner end /d:sonar.token="$(token)"
	dotnet build-server shutdown
cleanup:
	jb cleanupcode $(sln) --build
