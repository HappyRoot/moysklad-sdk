using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a product folder query.
    /// </summary>
    public class ProductFolderQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the path name.
        /// Note: 'order' is allowed.
        /// </summary>
        /// <value>The path name.</value>
        [AllowOrder]
        [Parameter("pathName")]
        public string PathName { get; set; }
            
        #endregion
    }
}