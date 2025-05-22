namespace ParseModel
{
    public class ModelParts
    {
        // Id
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
        public List<Face> Faces { get; set; } = new List<Face>();
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }

    public class Vertex
    { 
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class Face
    { 
        public List<int> VertexIndices { get; set; } = new List<int>();
    }

    public class IndustialModel
    { 
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FileName { get; set; } = string.Empty;
        public string FileFormat { get; set; } = string.Empty;
        public DateTime ImportDate { get; set; } = DateTime.Now;

        // 模型基本信息
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // 模型几何数据
        public List<ModelParts> Parts { get; set; } = new List<ModelParts>();
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        // 可视化数据渲染
        public string ViewerData { get; set; } = string.Empty;
    }
}
