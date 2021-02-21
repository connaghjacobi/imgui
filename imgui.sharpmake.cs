using Sharpmake;
using System.IO;
using System.Collections.Generic;

namespace imgui {

  [Generate]
  public class imgui : Project {
    public imgui(){
      Name = "imgui";
      AddTargets(new Target(
                Platform.win64,
                DevEnv.vs2019,
                Optimization.Debug | Optimization.Release,
                OutputType.Lib | OutputType.Dll,
                Blob.NoBlob
                ));
      SourceRootPath = @"[project.SharpmakeCsPath]/";
    }

    [Configure]
    public void ConfigureAll(Configuration conf, Target target){
      conf.IncludePaths.Add(@"[project.SharpmakeCsPath]/"); 

      conf.Name = @"[target.Optimization]-[target.Platform]-[target.OutputType]";
      conf.ProjectPath = Path.Combine(@"[project.SharpmakeCsPath]");
              
      conf.IntermediatePath = @"bin-int/[target.Optimization]-[target.Platform]/[project.Name]";
      conf.TargetPath =@"bin/[target.Optimization]-[target.Platform]/[project.Name]";
      conf.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
      conf.Options.Add(Options.Vc.Compiler.CppLanguageStandard.CPP17);
      if(target.OutputType == OutputType.Lib){
        conf.Output = Configuration.OutputType.Lib;
      } else {
        conf.Output = Configuration.OutputType.Dll;

      }
    }

  }

}