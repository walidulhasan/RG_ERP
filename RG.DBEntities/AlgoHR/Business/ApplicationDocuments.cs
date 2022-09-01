namespace RG.DBEntities.AlgoHR.Business
{
    public class ApplicationDocuments : DefaultTableProperties
    {
        public int DocumentID { get; set; }
        public int ApplicationID { get; set; }
        public int DocumentTypeID { get; set; }
        public string DocumentPath { get; set; }
        public string FileType { get; set; }
    }
}
