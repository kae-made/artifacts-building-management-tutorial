// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 1.0.0
//  
//     Updates this file cause incorrect behavior 
//     and will be lost when the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;
using Kae.Utility.Logging;
using Kae.DomainModel.Csharp.Framework;
using Kae.DomainModel.Csharp.Framework.Adaptor.ExternalStorage;

namespace BuildingManagement
{
    public partial class DomainClassCEBase : DomainClassCE
    {
        protected static readonly string className = "CE";

        public string DomainName { get { return CIMBuildingManagementLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"CustomerEngineerId={attr_CustomerEngineerId}"; }

        public static DomainClassCEBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassCEBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CE(CustomerEngineerId={newInstance.Attr_CustomerEngineerId}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassCEBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_CustomerEngineerId = Guid.NewGuid().ToString();
        }
        protected string attr_CustomerEngineerId;
        protected bool stateof_CustomerEngineerId = false;

        protected string attr_Name;
        protected bool stateof_Name = false;

        public string Attr_CustomerEngineerId { get { return attr_CustomerEngineerId; } set { attr_CustomerEngineerId = value; stateof_CustomerEngineerId = true; } }
        public string Attr_Name { get { return attr_Name; } set { attr_Name = value; stateof_Name = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassCE instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "CustomerEngineerId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_CustomerEngineerId)
                        {
                            result = false;
                        }
                        break;
                    case "Name":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_Name)
                        {
                            result = false;
                        }
                        break;
                }
                if (result== false)
                {
                    break;
                }
            }
            return result;
        }

        public DomainClassWA LinkedR7OneContract()
        {
            var candidates = instanceRepository.GetDomainInstances("WA").Where(inst=>(this.Attr_CustomerEngineerId==((DomainClassWA)inst).Attr_CustomerEngineerId));
            if (candidates.Count() == 0)
            {
                if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "WA", "R7_Contract", candidates, () => { return DomainClassWABase.CreateInstance(instanceRepository, logger); }, "any").Result;
                if (candidates.Count() > 0) ((DomainClassWA)candidates.FirstOrDefault()).LinkedR7OtherResponsiblePerson();
            }
            return (DomainClassWA)candidates.FirstOrDefault();
        }



        
        public bool Validate()
        {
            bool isValid = true;
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CE(CustomerEngineerId={this.Attr_CustomerEngineerId}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("CustomerEngineerId"))
            {
                attr_CustomerEngineerId = (string)propertyValues["CustomerEngineerId"];
            }
            stateof_CustomerEngineerId = false;
            if (propertyValues.ContainsKey("Name"))
            {
                attr_Name = (string)propertyValues["Name"];
            }
            stateof_Name = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_CustomerEngineerId)
            {
                results.Add("CustomerEngineerId", attr_CustomerEngineerId);
                stateof_CustomerEngineerId = false;
            }
            if (stateof_Name)
            {
                results.Add("Name", attr_Name);
                stateof_Name = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"CustomerEngineerId={this.Attr_CustomerEngineerId}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            results.Add("CustomerEngineerId", attr_CustomerEngineerId);
            if (!onlyIdentity) results.Add("Name", attr_Name);

            return results;
        }

#if false
        List<ChangedState> changedStates = new List<ChangedState>();

        public IList<ChangedState> ChangedStates()
        {
            List<ChangedState> results = new List<ChangedState>();
            results.AddRange(changedStates);
            results.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Update, Target = this, ChangedProperties = ChangedProperties() });
            changedStates.Clear();

            return results;
        }
#endif
    }
}
