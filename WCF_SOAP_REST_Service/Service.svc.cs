using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace WCF_SOAP_REST_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    public class Service : IService
    {
        public MaterialWeight[] GetMaterialWeights()
        {
            try
            {
                MaterialWeightDatabase db = new MaterialWeightDatabase();
                return db.GetMaterialWeightList().ToArray();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message,
                    new FaultCode(ex.GetType().Name));
            }
        }

        public int InsertMaterialWeight(MaterialWeight materialWeight)
        {
            try
            {
                MaterialWeightDatabase db = new MaterialWeightDatabase();
                return db.AddMaterialWeight(materialWeight).MatWeightNo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message,
                    new FaultCode(ex.GetType().Name));
            }
        }

        public MaterialWeight SelectMaterialWeight(int matWeightNo)
        {
            try
            {
                MaterialWeightDatabase db = new MaterialWeightDatabase();
                return db.FindMaterialWeight(matWeightNo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message,
                    new FaultCode(ex.GetType().Name));
            }
        }

        public int UpdateMaterialWeight(int matWeightNo, MaterialWeight materialWeight)
        {
            try
            {
                MaterialWeightDatabase db = new MaterialWeightDatabase();
                return db.UpdateMaterialWeight(matWeightNo, materialWeight).MatWeightNo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message,
                    new FaultCode(ex.GetType().Name));
            }
        }

        public int DeleteMaterialWeight(int matWeightNo)
        {
            try
            {
                MaterialWeightDatabase db = new MaterialWeightDatabase();
                return db.RemoveMaterialWeight(matWeightNo).MatWeightNo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message,
                    new FaultCode(ex.GetType().Name));
            }
        }


    }
}
