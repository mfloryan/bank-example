require 'albacore'
require 'rake/clean'
require 'meerkat'
require 'yaml'

METADATA = YAML.load_file('package.yml')

@build_number = ENV['GO_PIPELINE_LABEL'] || '1'
@version = "0.1." << @build_number

@application_source = "src"
@build_output_dir = "build"
@tools_dir = "./tools"
@version_dir = "src/Version"
@unit_test_dir = "src/#{METADATA['component']}.Tests/bin/Release"

task :default  => [:start, :compile, :run_unit_tests, :end]

CLEAN.include (FileList["./src/**/obj"])
CLEAN.include (FileList["./src/**/bin"])
CLEAN.include (@build_output_dir)

Albacore.configure do |config|
  config.log_level = :info
  
  config.msbuild do |msb|
    msb.use :net40
    msb.solution = "src/#{METADATA['component']}.sln"
  end
  
  config.nunit do | nunit |
    nunit.command = "src/packages/NUnit.Runners.2.6.2/tools/nunit-console.exe"
    nunit.options = "/framework v4.0.30319", "/nologo", "/noshadow", "/out:TestResult.txt"
  end
end

desc "Run a build using the MSBuildTask"
ctm_build :compile => :assemblyinfo do |msb|
  msb.properties :configuration => :Release
  msb.maxcpucount= "4"
  msb.loggermodule = "ConsoleLogger,Microsoft.Build.Engine"
  msb.verbosity = "q"
  msb.targets :Clean, :Build
end

desc "Generate Assembly Version Infomation"
assemblyinfo :assemblyinfo do |asm|  
  mkdir @version_dir unless File.exists?(@version_dir) 
  asm.version = @version << ".*"
  asm.output_file = "#{@version_dir}/ApplicationVersionInfo.cs"
end

desc "Run unit tests"
nunit :run_unit_tests do | nunit | 
  puts "\n[TEST] Running unit tests..\n"
  nunit.working_directory = @unit_test_dir
  nunit.assemblies "#{METADATA['component']}.Tests.dll"
end

task :start do
  puts "[#{METADATA['component']} Build] Starting Build ... \n"
end

task :end do
  puts "[#{METADATA['component']} Build] Build Complete"
end
