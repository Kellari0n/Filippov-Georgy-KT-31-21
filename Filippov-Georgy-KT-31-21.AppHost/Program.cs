internal class Program {
    private static void Main(string[] args) {
        var builder = DistributedApplication.CreateBuilder(args);
        
        var postgresServer = builder.AddPostgres("postgresServer")
            .WithPgAdmin()
            .WithDataVolume(isReadOnly: false);
        
        var teachersDb = postgresServer.AddDatabase("Teachers");
        
        var teacherService = builder.AddProject<Projects.Filippov_Georgy_KT_31_21_TeacherService>("teacherservice")
            .WithReference(teachersDb)
            .WaitFor(teachersDb);
        
        builder.AddProject<Projects.Filippov_Georgy_KT_31_21_DepartmentService>("departmentservice")
            .WithReference(teacherService);
        
        builder.Build().Run();
    }
}