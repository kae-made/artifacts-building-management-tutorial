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
    public partial class DomainClassRBase : DomainClassR
    {
        protected static readonly string className = "R";

        public string DomainName { get { return CIMBuildingManagementLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"RoomId={attr_RoomId}"; }

        public static DomainClassRBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassRBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:R(RoomId={newInstance.Attr_RoomId}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassRBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_RoomId = Guid.NewGuid().ToString();
        }
        protected string attr_RoomId;
        protected bool stateof_RoomId = false;

        protected string attr_FloorId;
        protected bool stateof_FloorId = false;

        protected string attr_RoomName;
        protected bool stateof_RoomName = false;

        protected DomainTypeEnvironmentPhysicalQuantities attr_CurrentEnvironment = new DomainTypeEnvironmentPhysicalQuantities() ;
        protected bool stateof_CurrentEnvironment = false;

        protected DomainTypeEnvironmentPhysicalQuantities attr_PreferredEnvironment = new DomainTypeEnvironmentPhysicalQuantities() ;
        protected bool stateof_PreferredEnvironment = false;

        public string Attr_RoomId { get { return attr_RoomId; } set { attr_RoomId = value; stateof_RoomId = true; } }
        public string Attr_FloorId { get { return attr_FloorId; } }
        public string Attr_RoomName { get { return attr_RoomName; } set { attr_RoomName = value; stateof_RoomName = true; } }
        public DomainTypeEnvironmentPhysicalQuantities Attr_CurrentEnvironment { get { return attr_CurrentEnvironment; } set { attr_CurrentEnvironment = value; stateof_CurrentEnvironment = true; } }
        public DomainTypeEnvironmentPhysicalQuantities Attr_PreferredEnvironment { get { return attr_PreferredEnvironment; } set { attr_PreferredEnvironment = value; stateof_PreferredEnvironment = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassR instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "RoomId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_RoomId)
                        {
                            result = false;
                        }
                        break;
                    case "FloorId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_FloorId)
                        {
                            result = false;
                        }
                        break;
                    case "RoomName":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_RoomName)
                        {
                            result = false;
                        }
                        break;
                    case "CurrentEnvironment":
                        if ((DomainTypeEnvironmentPhysicalQuantities)conditionPropertyValues[propertyName] != instance.Attr_CurrentEnvironment)
                        {
                            result = false;
                        }
                        break;
                    case "PreferredEnvironment":
                        if ((DomainTypeEnvironmentPhysicalQuantities)conditionPropertyValues[propertyName] != instance.Attr_PreferredEnvironment)
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
        protected LinkedInstance relR2F;
        public DomainClassF LinkedR2()
        {
            if (relR2F == null)
            {
                var candidates = instanceRepository.GetDomainInstances("F").Where(inst=>(this.Attr_FloorId==((DomainClassF)inst).Attr_FloorId));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "F", "R2", candidates, () => { return DomainClassFBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR2F = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R2", Phrase = "" };

            }
            return relR2F.GetDestination<DomainClassF>();
        }

        public bool LinkR2(DomainClassF instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR2F == null)
            {
                this.attr_FloorId = instance.Attr_FloorId;
                this.stateof_FloorId = true;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:R(RoomId={this.Attr_RoomId}):link[F(FloorId={instance.Attr_FloorId})]");

                result = (LinkedR2()!=null);
                if (result)
                {
                    if(changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR2F });
                }
            }
            return result;
        }

        public bool UnlinkR2(DomainClassF instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR2F != null && ( this.Attr_FloorId==instance.Attr_FloorId ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR2F });
        
                this.attr_FloorId = null;
                this.stateof_FloorId = true;
                relR2F = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:R(RoomId={this.Attr_RoomId}):unlink[F(FloorId={instance.Attr_FloorId})]");


                result = true;
            }
            return result;
        }

        public IEnumerable<DomainClassMI> LinkedR3()
        {
            var result = new List<DomainClassMI>();
            var candidates = instanceRepository.GetDomainInstances("MI").Where(inst=>(this.Attr_RoomId==((DomainClassMI)inst).Attr_TargetRoomId));
            if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "MI", "R3", candidates, () => { return DomainClassMIBase.CreateInstance(instanceRepository, logger); }, "many").Result;
            foreach (var c in candidates)
            {
                ((DomainClassMI)c).LinkedR3Measuaring();
                result.Add((DomainClassMI)c);
            }
            return result;
        }


        public IEnumerable<DomainClassAC> LinkedR4Installed()
        {
            var result = new List<DomainClassAC>();
            var candidates = instanceRepository.GetDomainInstances("AC").Where(inst=>(this.Attr_RoomId==((DomainClassAC)inst).Attr_TargetRoomId));
            if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "AC", "R4", candidates, () => { return DomainClassACBase.CreateInstance(instanceRepository, logger); }, "many").Result;
            foreach (var c in candidates)
            {
                ((DomainClassAC)c).LinkedR4();
                result.Add((DomainClassAC)c);
            }
            return result;
        }

        public DomainClassWL LinkedR5()
        {
            var candidates = instanceRepository.GetDomainInstances("WL").Where(inst=>(this.Attr_RoomId==((DomainClassWL)inst).Attr_TargetRoomId));
            if (candidates.Count() == 0)
            {
                if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "WL", "R5", candidates, () => { return DomainClassWLBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                if (candidates.Count() > 0) ((DomainClassWL)candidates.FirstOrDefault()).LinkedR5Target();
            }
            return (DomainClassWL)candidates.FirstOrDefault();
        }

        public DomainClassLC LinkedR8One()
        {
            var candidates = instanceRepository.GetDomainInstances("LC").Where(inst=>(this.Attr_RoomId==((DomainClassLC)inst).Attr_RoomId));
            if (candidates.Count() == 0)
            {
                if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "LC", "R8_", candidates, () => { return DomainClassLCBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                if (candidates.Count() > 0) ((DomainClassLC)candidates.FirstOrDefault()).LinkedR8Other();
            }
            return (DomainClassLC)candidates.FirstOrDefault();
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR2F == null)
            {
                isValid = false;
            }
            if (this.LinkedR4Installed().Count() == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:R(RoomId={this.Attr_RoomId}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("RoomId"))
            {
                attr_RoomId = (string)propertyValues["RoomId"];
            }
            stateof_RoomId = false;
            if (propertyValues.ContainsKey("FloorId"))
            {
                attr_FloorId = (string)propertyValues["FloorId"];
            }
            stateof_FloorId = false;
            if (propertyValues.ContainsKey("RoomName"))
            {
                attr_RoomName = (string)propertyValues["RoomName"];
            }
            stateof_RoomName = false;
            if (propertyValues.ContainsKey("CurrentEnvironment"))
            {
                attr_CurrentEnvironment.Restore((IDictionary<string, object>)propertyValues["CurrentEnvironment"]);
            }
            stateof_CurrentEnvironment = false;
            if (propertyValues.ContainsKey("PreferredEnvironment"))
            {
                attr_PreferredEnvironment.Restore((IDictionary<string, object>)propertyValues["PreferredEnvironment"]);
            }
            stateof_PreferredEnvironment = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_RoomId)
            {
                results.Add("RoomId", attr_RoomId);
                stateof_RoomId = false;
            }
            if (stateof_FloorId)
            {
                results.Add("FloorId", attr_FloorId);
                stateof_FloorId = false;
            }
            if (stateof_RoomName)
            {
                results.Add("RoomName", attr_RoomName);
                stateof_RoomName = false;
            }
            if (stateof_CurrentEnvironment)
            {
                results.Add("CurrentEnvironment", attr_CurrentEnvironment);
                stateof_CurrentEnvironment = false;
            }
            if (stateof_PreferredEnvironment)
            {
                results.Add("PreferredEnvironment", attr_PreferredEnvironment);
                stateof_PreferredEnvironment = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"RoomId={this.Attr_RoomId}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            results.Add("RoomId", attr_RoomId);
            if (!onlyIdentity) results.Add("FloorId", attr_FloorId);
            results.Add("RoomName", attr_RoomName);
            if (!onlyIdentity) results.Add("CurrentEnvironment", attr_CurrentEnvironment);
            if (!onlyIdentity) results.Add("PreferredEnvironment", attr_PreferredEnvironment);

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
