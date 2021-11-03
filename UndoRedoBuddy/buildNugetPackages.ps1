rm *.nupkg
nuget pack .\UndoRedoBuddy.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget pack .\UndoRedoBuddy.Bridge.nuspec -IncludeReferencedProjects -Prop Configuration=Release
cp *.nupkg C:\Projects\Nugets\
nuget push -source https://www.nuget.org -NonInteractive *.nupkg