using Remap.Sdk.Entities.Documents;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an payment document.
    /// </summary>
    public abstract class PaymentDocument : ProjectContractDocument
    {
        #region Properties

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public Counterparty Agent { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the payment purpose.
        /// </summary>
        /// <value>The payment purpose.</value>
        public string PaymentPurpose { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public Rate Rate { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the vat sum.
        /// </summary>
        /// <value>The vat sum.</value>
        public long? VatSum { get; set; }

        #endregion Properties
    }
}