using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchTestProject
{
    public class BUUUpdate
    {
        public string RECORD_CODE
        { get; set; }

        public string FIL_TP_ID
        { get; set; }

        public string FIL_SPOE_ID
        { get; set; }

        public string TENNANT_ID
        { get; set; }

        public string HIOS_ID
        { get; set; }

        public string QHPID_LKP_KEY
        { get; set; }

        public string ISSUER_EXTRCT_DT
        { get; set; }

        public string FFM_PRSN_1ST_NAME
        { get; set; }

        public string ISSUER_PRSN_1ST_NAME
        { get; set; }

        public string FTI_PRSN_1ST_NAME_FLAG
        { get; set; }

        public string FFM_PRSN_MDL_NAME
        { get; set; }

        public string ISSUER_PRSN_MDL_NAME
        { get; set; }

        public string FTI_PRSN_MDL_NAME_FLAG
        { get; set; }

        public string FFM_PRSN_LAST_NAME
        { get; set; }

        public string ISSUER_PRSN_LAST_NAME
        { get; set; }

        public string FTI_PRSN_LAST_NAME_FLAG
        { get; set; }

        public string FFM_PRSN_BIRTH_DT
        { get; set; }

        public string ISSUER_PRSN_BIRTH_DT
        { get; set; }

        public string FTI_PRSN_BIRTH_DT_FLAG
        { get; set; }

        public string FFM_PRSN_GNDR_CD
        { get; set; }

        public string ISSUER_PRSN_GNDR_CD
        { get; set; }

        public string FTI_PRSN_GNDR_CD_FLAG
        { get; set; }

        public string FFM_BENE_SSN_KEY
        { get; set; }

        public string ISSUER_BENE_SSN_KEY
        { get; set; }

        public string FTI_BENE_SSN_KEY_FLAG
        { get; set; }

        public string FFM_BENE_SBSCBR_IND
        { get; set; }

        public string ISSUER_BENE_SBSCBR_IND
        { get; set; }

        public string FTI_BENE_SBSCBR_IND_FLG
        { get; set; }

        public string FFM_BENE_RLTNSHP_CD
        { get; set; }

        public string ISSUER_BENE_RLTNSHP_CD
        { get; set; }

        public string FTI_BENE_RLTNSHP_CD_FLG
        { get; set; }

        public string FFM_BENE_SBS_EXCHG_ASG_ID
        { get; set; }

        public string ISSUER_BENE_SBS_EXCHG_ASG_ID
        { get; set; }

        public string FTI_BENE_SBS_EXCHG_ASG_ID_FLG
        { get; set; }

        public string FFM_BENE_EXCHG_ASGNED_ID
        { get; set; }

        public string ISSUER_BENE_EXCHG_ASGNED_ID
        { get; set; }

        public string FTI_BENE_EXCHG_ASGNED_ID_FLG
        { get; set; }

        public string FFM_BENE_SBS_ISSR_ASG_ID
        { get; set; }

        public string ISSUER_BENE_SBS_ISSR_ASG_ID
        { get; set; }

        public string FTI_BENE_SBS_ISR_ASG_ID_FLG
        { get; set; }

        public string FFM_BENE_ISSR_ASGNED_ID
        { get; set; }

        public string ISSUER_BENE_ISSR_ASGNED_ID
        { get; set; }

        public string FTI_BENE_ISSR_ASGNED_ID_FLG
        { get; set; }

        public string FFM_PLAN_EXCHG_ASG_PLCY_NUM
        { get; set; }

        public string ISS_PLAN_EXCHG_ASG_PLCY_NUM
        { get; set; }

        public string FTI_PLN_EXCHG_ASG_PLCY_NUM_FLG
        { get; set; }

        public string FFM_PLAN_ISSR_ASG_PLCY_NUM
        { get; set; }

        public string ISSUER_PLAN_ISSR_ASG_PLCY_NUM
        { get; set; }

        public string FTI_PLAN_ISR_ASG_PLCY_NUM_FLG
        { get; set; }

        public string FFM_PRSN_RSDNTL_ADR_L1_TXT
        { get; set; }

        public string ISSUER_PRSN_RSDNTL_ADR_L1_TXT
        { get; set; }

        public string FTI_PRSN_RSDNTL_ADR_L1_TXT_FLG
        { get; set; }

        public string FFM_PRSN_RSDNTL_ADR_L2_TXT
        { get; set; }

        public string ISSUER_PRSN_RSDNTL_ADR_L2_TXT
        { get; set; }

        public string FTI_PRSN_RSDNTL_ADR_L2_TXT_FLG
        { get; set; }

        public string FFM_PRSN_RSDNTL_CITY_NAME
        { get; set; }

        public string ISSUER_PRSN_RSDNTL_CITY_NAME
        { get; set; }

        public string FTI_PRSN_RSDNTL_CITY_NAME
        { get; set; }

        public string FFM_PRSN_RSDNTL_STATE_CD
        { get; set; }

        public string ISSUER_PRSN_RSDNTL_STATE_CD
        { get; set; }

        public string FTI_PRSN_RSDNTL_STATE_CD_FLG
        { get; set; }

        public string FFM_PRSN_RSDNTL_ZIP_CD
        { get; set; }

        public string ISSUER_PRSN_RSDNTL_ZIP_CD
        { get; set; }

        public string FTI_PRSN_RSDNTL_ZIP_CD_FLG
        { get; set; }

        public string FFM_PRSN_MLG_ADR_LINE_1_TXT
        { get; set; }

        public string ISSUER_PRSN_MLG_ADR_LINE_1_TXT
        { get; set; }

        public string FTI_PRSN_MLG_ADR_LNE_1_TXT_FLG
        { get; set; }

        public string FFM_PRSN_MLG_ADR_LINE_2_TXT
        { get; set; }

        public string ISSUER_PRSN_MLG_ADR_LINE_2_TXT
        { get; set; }

        public string FTI_PRSN_MLG_ADR_LNE_2_TXT_FLG
        { get; set; }

        public string FFM_PRSN_MLG_ADR_CITY_NAME
        { get; set; }

        public string ISSUER_PRSN_MLG_ADR_CITY_NAME
        { get; set; }

        public string FTI_PRSN_MLG_ADR_CITY_NAME_FLG
        { get; set; }

        public string FFM_PRSN_MLG_ADR_STATE_CD
        { get; set; }

        public string ISSUER_PRSN_MLG_ADR_STATE_CD
        { get; set; }

        public string FTI_PRSN_MLG_ADR_STATE_CD_FLG
        { get; set; }

        public string FFM_PRSN_MLG_ADR_ZIP_CD
        { get; set; }

        public string ISSUER_PRSN_MLG_ADR_ZIP_CD
        { get; set; }

        public string FTI_PRSN_MLG_ADR_ZIP_CD_FLG
        { get; set; }

        public string FFM_PRSN_RSDNTL_CNTRY_CD
        { get; set; }

        public string ISSUER_PRSN_RSDNTL_CNTRY_CD
        { get; set; }

        public string FTI_PRSN_RSDNTL_CNTRY_CD_FLG
        { get; set; }

        public string FFM_PLAN_EXCHG_RATE_AREA_ID
        { get; set; }

        public string ISSUER_PLAN_EXCHG_RATE_AREA_ID
        { get; set; }

        public string FTI_PLN_EXCHG_RATE_AREA_ID_FLG
        { get; set; }

        public string FFM_PRSN_PHNE_NUM
        { get; set; }

        public string ISSUER_PRSN_PHNE_NUM
        { get; set; }

        public string FTI_PRSN_PHNE_NUM_FLG
        { get; set; }

        public string FFM_PRSN_SMKNG_USE_CD
        { get; set; }

        public string ISSUER_PRSN_SMKNG_USE_CD
        { get; set; }

        public string FTI_PRSN_SMKNG_USE_CD_FLG
        { get; set; }

        public string FFM_PLAN_PLCY_ID
        { get; set; }

        public string ISSUER_PLAN_PLCY_ID
        { get; set; }

        public string FTI_PLAN_PLCY_ID_FLG
        { get; set; }

        public string FFM_PLAN_BNFT_STRT_DT
        { get; set; }

        public string ISSUER_PLAN_BNFT_STRT_DT
        { get; set; }

        public string FTI_PLAN_BNFT_STRT_DT_FLG
        { get; set; }

        public string FFM_PLAN_BNFT_END_DT
        { get; set; }

        public string ISSUER_PLAN_BNFT_END_DT
        { get; set; }

        public string FTI_PLAN_BNFT_END_DT_FLG
        { get; set; }

        public string FFM_PLCY_APTC_AMT
        { get; set; }

        public string ISSUER_PLCY_APTC_AMT
        { get; set; }

        public string FTI_PLCY_APTC_AMT_FLG
        { get; set; }

        public string FFM_PLCY_APTC_EFCTV_DT
        { get; set; }

        public string ISSUER_PLCY_APTC_EFCTV_DT
        { get; set; }

        public string FTI_PLCY_APTC_EFCTV_DT_FLG
        { get; set; }

        public string FFM_PLCY_APTC_END_DT
        { get; set; }

        public string ISSUER_PLCY_APTC_END_DT
        { get; set; }

        public string FTI_PLCY_APTC_END_DT_FLG
        { get; set; }

        public string FFM_PLCY_CSR_AMT
        { get; set; }

        public string ISSUER_PLCY_CSR_AMT
        { get; set; }

        public string FTI_PLCY_CSR_AMT_FLG
        { get; set; }

        public string FFM_PLCY_CSR_EFCTV_DT
        { get; set; }

        public string ISSUER_PLCY_CSR_EFCTV_DT
        { get; set; }

        public string FTI_PLCY_CSR_EFCTV_DT_FLG
        { get; set; }

        public string FFM_PLCY_CSR_END_DT
        { get; set; }

        public string ISSUER_PLCY_CSR_END_DT
        { get; set; }

        public string FTI_PLCY_CSR_END_DT_FLG
        { get; set; }

        public string FFM_PLCY_TOT_PRM_AMT
        { get; set; }

        public string ISSUER_PLCY_TOT_PRM_AMT
        { get; set; }

        public string FTI_PLCY_TOT_PRM_AMT_FLG
        { get; set; }

        public string FFM_PLN_PLCY_TOT_PM_EFCDT
        { get; set; }

        public string ISSUER_PLN_PLCY_TOT_PM_EFCDT
        { get; set; }

        public string FTI_PLN_PLCY_TOT_PM_EFCDT_FLG
        { get; set; }

        public string FFM_PLCY_TOT_PRM_END_DT
        { get; set; }

        public string ISSUER_PLCY_TOT_PRM_END_DT
        { get; set; }

        public string FTI_PLCY_TOT_PRM_END_DT_FLG
        { get; set; }

        public string FFM_PLCY_IND_MMBR_PRM_AMT
        { get; set; }

        public string ISSUER_PLCY_IND_MMBR_PRM_AMT
        { get; set; }

        public string FTI_PLCY_IND_MMBR_PRM_AMT_FLG
        { get; set; }

        public string FFM_PLCY_IND_MMBR_PRM_EFCDT
        { get; set; }

        public string ISSUER_PLCY_IND_MMBR_PRM_EFCDT
        { get; set; }

        public string FTI_PLCY_IND_MBR_PRM_EFCDT_FLG
        { get; set; }

        public string FFM_PLCY_IND_MMBR_PRM_END_DT
        { get; set; }

        public string ISS_PLCY_IND_MMBR_PRM_END_DT
        { get; set; }

        public string FTI_PLCY_IND_MBR_PRM_ENDT_FLG
        { get; set; }

        public string FFM_PRM_PD_IND
        { get; set; }

        public string ISSUER_PRM_PD_IND
        { get; set; }

        public string FTI_PRM_PD_IND_FLAG
        { get; set; }

        public string FTI_ISSUER_OVERALL_RECORD_FLAG
        { get; set; }

        public string FFM_INTERNAL_INVENTORY_RECORD
        { get; set; }

        public string FTI_ISSUER_LINK_KEY
        { get; set; }

        public string FTI_INTERNAL_BATCH_ID
        { get; set; }

        public string MASTER_POLICY_NUMBER
        { get; set; }

        public string COGNASANTE_IND
        { get; set; }

        public string COGNASANTE_ACTN_RQRD_IND
        { get; set; }

        public string CIC_CORRELATION_KEY
        { get; set; }

        public string PLCY_LAST_MNTNC_DT_TM
        { get; set; }

        public string TRANS_TYPE_CD
        { get; set; }

        public string PLCY_LAST_SYS_ACTV_DT_TM
        { get; set; }

        public string FFM_PLAN_BNFT_YEAR
        { get; set; }

        public string ISSR_PLAN_BNFT_YEAR
        { get; set; }

        public string FTI_PLAN_BNFT_YEAR_FLAG
        { get; set; }

        public string FFM_PD_THRU_DT
        { get; set; }

        public string ISSR_PD_THRU_DT
        { get; set; }

        public string FTI_PD_THRU_DT_FLAG
        { get; set; }

        public string FFM_END_YR_VLNTRY_TRM_IND
        { get; set; }

        public string ISSR_END_YR_VLNTRY_TRM_IND
        { get; set; }

        public string FTI_END_YR_VLNTRY_TRM_IND_FLAG
        { get; set; }

        public string FFM_AGNCY_BROKR_1ST_NAME
        { get; set; }

        public string ISSR_AGNCY_BROKR_1ST_NAME
        { get; set; }

        public string FTI_AGNCY_BROKR_1ST_NAME_FLAG
        { get; set; }

        public string FFM_AGNCY_BROKR_MDL_NAME
        { get; set; }

        public string ISSR_AGNCY_BROKR_MDL_NAME
        { get; set; }

        public string FTI_AGNCY_BROKR_MDL_NAME_FLAG
        { get; set; }

        public string FFM_AGNCY_BROKR_LAST_NAME
        { get; set; }

        public string ISSR_AGNCY_BROKR_LAST_NAME
        { get; set; }

        public string FTI_AGNCY_BROKR_LAST_NAME_FLAG
        { get; set; }

        public string FFM_AGNCY_BROKR_NPN_NUM
        { get; set; }

        public string ISSR_AGNCY_BROKR_NPN_NUM
        { get; set; }

        public string FTI_AGNCY_BROKR_NPN_NUM_FLAG
        { get; set; }

        public string FFM_ENRLMNT_GRP_MEMBERS
        { get; set; }

        public string ISS_ENRLMNT_GRP_MEMBERS
        { get; set; }

        public string FTI_ENRLMNT_GRP_MEMBERS_FLG
        { get; set; }

        public string FFM_PLAN_EXCHG_ASGNED_PLCY_SEG
        { get; set; }

        public string FFM_PLAN_PLCY_SEG_SUPRSDD_IND
        { get; set; }

        public string ISSR_PLAN_PLCY_SEG_SUPRSDD_IND
        { get; set; }

        public string FTI_PLN_PLCY_SEG_SPRSD_IND_FLG
        { get; set; }

        public string INV_RECORD_REFERENCE
        { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                sb.Append((string)property.GetValue(this, null) + '|');
            }

            return sb.ToString().TrimEnd(new char[] { '|' });

        }
    }
}
