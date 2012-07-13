$framework = '4.0'
$script:project_config = "Release"

properties {
   $project_name = "MvcAppCache"
   $build_number = 1
   $version = "1.0.$build_number.0"

   $base_dir = resolve-path .
   $source_dir = "$base_dir\src"
   $tools_dir = "$base_dir\lib"

   # Tests
   $nunitConsole = "$base_dir\lib\NUnit\nunit-console.exe"
   $tests_dir = "$base_dir\tests\"
 }

task default -depends Clean, Compile, RunTests

task Compile {
   exec { msbuild.exe /t:build /v:q /p:Configuration=$project_config /nologo $source_dir\$project_name.sln }
}

task Clean {
   create_directory $tests_dir

   exec { msbuild /t:clean /v:q /p:Configuration=$project_config /nologo $source_dir\$project_name.sln }
}

task RunTests -depends Compile {
   exec { & $nunitConsole $source_dir\$project_name.Tests\bin\$project_config\$project_name.Tests.dll /nologo /xml=$tests_dir\tests.xml }
}

# Global Functions =============================================================

function global:create_directory($directory_name) {
   mkdir $directory_name  -ErrorAction SilentlyContinue | out-null
}