internal class Program {
    private static void Main(string[] args) {
        var builder = DistributedApplication.CreateBuilder(args);

        builder.AddProject<Projects.Filippov_Georgy_KT_31_21_DepartmentService>("departmentservice");

        builder.Build().Run();
    }
}