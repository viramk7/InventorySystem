
using System.Globalization;
using Resources.Abstract;
using Resources.Concrete;

namespace Resources
{
    public class Resources
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider();
		
		/// <summary>Record saved successfully.</summary>
        public static string SaveSuccess
        {
            get
            {
                return (string)resourceProvider.GetResource("SaveSuccess", CultureInfo.CurrentUICulture.Name);
            }
        }
		
		/// <summary>Could not save the record.</summary>
        public static string SaveFailed
        {
            get
            {
                return (string)resourceProvider.GetResource("SaveFailed", CultureInfo.CurrentUICulture.Name);
            }
        }
		
		/// <summary>Record deleted successfully.</summary>
        public static string DeleteSuccess
        {
            get
            {
                return (string)resourceProvider.GetResource("DeleteSuccess", CultureInfo.CurrentUICulture.Name);
            }
        }
		
		/// <summary>Could not delete the record.</summary>
        public static string DeleteFailed
        {
            get
            {
                return (string)resourceProvider.GetResource("DeleteFailed", CultureInfo.CurrentUICulture.Name);
            }
        }
		
		/// <summary>Something went wrong.</summary>
        public static string ServerError
        {
            get
            {
                return (string)resourceProvider.GetResource("ServerError", CultureInfo.CurrentUICulture.Name);
            }
        }
		
		/// <summary>This is abc</summary>
        public static string abc
        {
            get
            {
                return (string)resourceProvider.GetResource("abc", CultureInfo.CurrentUICulture.Name);
            }
        }
			}
}