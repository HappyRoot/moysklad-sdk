using Confiti.MoySklad.Remap.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remap.Sdk.Entities.Documents
{
    /// <summary>
    /// Represents the document that may have Contract and Project
    /// </summary>
    public abstract class ProjectContractDocument: Document
    {

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        public Contract Contract { get; set; }


        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public Project Project { get; set; }
    }
}
