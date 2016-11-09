param($rootPath, $toolsPath, $package, $project)

"Installing Specflow.Roslyn to project [{0}]" -f $project.FullName | Write-Host

#Write-Host $rootPath 
#Write-Host $toolsPath
#Write-Host $package
#Write-Host $project

#########################
# Start of script here
#########################

$projFile = $project.FullName
Write-Host "The project being installed into is $projFile"

# Make sure that the project file exists
if(!(Test-Path $projFile)){
    throw ("Project file not found at [{0}]" -f $projFile)
}

$projectDirectory = [System.IO.Path]::GetDirectoryName($project.FullName)
Push-Location $projectDirectory
$packageDllPath = "$rootPath\tools\"
$pluginPath = Resolve-Path -Relative $packageDllPath
Pop-Location


$xml = New-Object xml

# find the App.config file
$config = $project.ProjectItems | where {$_.Name -eq "App.config"}

if ($config -eq $null)
{
	throw "There must be an app.config into which we can add the specflow configuration"
}

# find its path on the file system
$localPath = $config.Properties | where {$_.Name -eq "LocalPath"}

# load Web.config as XML
$xml.Load($localPath.Value)

$xml.OuterXml |write-host

"Getting the specflow node" | write-host
# select the node
$specflowNode = $xml.SelectSingleNode("configuration/specFlow")

$specflowNode.OuterXml |Write-host

"Getting the step assemblies node" | write-host
$stepAssembliesNode = $specflowNode.SelectSingleNode("stepAssemblies")
if ($stepAssembliesNode -eq $null)
{
		"Theer was no stepAssemblies node, creating it" | write-host
	$stepAssembliesNode = $xml.CreateElement("stepAssemblies") 
	$specflowNode.AppendChild($stepAssembliesNode);
}
"Getting the Roslyn Steps node" | write-host

$stepAssemblyNode = $stepAssembliesNode.SelectSingleNode("stepAssembly [@assembly='Specflow.Roslyn']")
if ($stepAssemblyNode -eq $null)
{
	"theer was no roslyn steps node, creating one" | write-host
	$stepAssemblyNode = $xml.CreateElement("stepAssembly")
	$stepAssemblyNode.SetAttribute("assembly","Specflow.Roslyn")
	$stepAssembliesNode.AppendChild($stepAssemblyNode)
}



# save the App.config.config file
$xml.Save($localPath.Value)


"    Specflow.Roslyn has been installed into project [{0}]" -f $project.FullName| Write-Host -ForegroundColor DarkGreen
