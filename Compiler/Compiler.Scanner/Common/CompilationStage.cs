namespace Compiler.Scanner.Common
{
    public enum CompilationStage
    {
        None,
        PreProcessing,
        Scanning,
        Parsing,
        SemanticAnalysis,
        CodeGeneration,
        PostProcessing,
        Other
    }
}
