sln = Mulier.sln
token = sqp_a55e0efe1dae0d2e9792809e671051f45a2e21a3
sonarqube = http://sonarqube.gajda.co.uk/

all:
	dotnet sonarscanner begin /k:"Mulier" /d:sonar.token="$(token)" /d:sonar.host.url="$(sonarqube)" /d:sonar.cs.vscoveragexml.reportsPaths="coverage.xml"
	dotnet build --no-incremental
	dotnet-coverage collect "dotnet test" --output-format xml --output "coverage.xml"
	dotnet sonarscanner end /d:sonar.token="$(token)"
	dotnet build-server shutdown
cleanup:
	jb cleanupcode $(sln) --build
