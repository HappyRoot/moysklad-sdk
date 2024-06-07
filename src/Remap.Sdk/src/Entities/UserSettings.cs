using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSettingsDefaultCompany
    {
        /// <summary>
        /// 
        /// </summary>
        public Meta Meta { get; set; }

        
    }

    /// <summary>
    /// 
    /// </summary>
    public class UserSettingsDefaultPlace
    {
        /// <summary>
        /// 
        /// </summary>
        public Meta Meta { get; set; }
    }

    /// <summary>
    /// Represents an unit of measure.
    /// </summary>
    public class UserSettings
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserSettingsDefaultCompany DefaultCompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserSettingsDefaultPlace DefaultPlace { get; set; }

        /// <summary>
        /// Gets or sets the Locale.
        /// </summary>
        /// <value>The description.</value>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the fieldsPerRow
        /// </summary>
        /// <value>The external code.</value>
        public int FieldsPerRow { get; set; }

        /// <summary>
        /// Gets or sets the defaultScreen.
        /// </summary>
        /// <value>The group.</value>
        public string DefaultScreen { get; set; }

        /// <summary>
        /// Gets or sets the MailFooter.
        /// </summary>
        /// <value>The owner.</value>
        public string MailFooter { get; set; }

        /// <summary>
        /// Gets or sets the AutoShowReports
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        public bool AutoShowReports { get; set; }

        #endregion Properties
    }
}