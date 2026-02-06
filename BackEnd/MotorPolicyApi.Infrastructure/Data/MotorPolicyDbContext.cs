using Microsoft.EntityFrameworkCore;
using MotorPolicyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Infrastructure.Data
{
    public class MotorPolicyDbContext : DbContext
    {
        public MotorPolicyDbContext(DbContextOptions<MotorPolicyDbContext> options)
            : base(options)
        {
        }

        public DbSet<CodesMaster> CodesMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<MotorPolicy> MotorPolicies { get; set; }
        public DbSet<MotorClaim> MotorClaims { get; set; }
        public DbSet<MotorClmSurHdr> MotorClmSurHdrs { get; set; }
        public DbSet<MotorClmSurDtl> MotorClmSurDtls { get; set; }
        public DbSet<MotorClmSurDtlHist> MotorClmSurDtlHists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // CODES_MASTER
            // =========================
            modelBuilder.Entity<CodesMaster>(entity =>
            {
                entity.ToTable("CODES_MASTER");

                entity.HasKey(e => new { e.CmCode, e.CmType });

                entity.Property(e => e.CmCode).HasColumnName("CM_CODE");
                entity.Property(e => e.CmType).HasColumnName("CM_TYPE");
                entity.Property(e => e.CmDesc).HasColumnName("CM_DESC");
                entity.Property(e => e.CmValue).HasColumnName("CM_VALUE");
                entity.Property(e => e.CmCrBy).HasColumnName("CM_CR_BY");
                entity.Property(e => e.CmCrDt).HasColumnName("CM_CR_DT");
                entity.Property(e => e.CmUpBy).HasColumnName("CM_UP_BY");
                entity.Property(e => e.CmUpDt).HasColumnName("CM_UP_DT");
                entity.Property(e => e.CmActiveYn).HasColumnName("CM_ACTIVE_YN");
            });

            // =========================
            // ERROR_CODE_MASTER
            // =========================
            modelBuilder.Entity<ErrorCodeMaster>(entity =>
            {
                entity.ToTable("ERROR_CODE_MASTER");

                entity.HasKey(e => new { e.ErrCode, e.ErrType });

                entity.Property(e => e.ErrCode).HasColumnName("ERR_CODE");
                entity.Property(e => e.ErrType).HasColumnName("ERR_TYPE");
                entity.Property(e => e.ErrDesc).HasColumnName("ERR_DESC");
                entity.Property(e => e.ErrCrBy).HasColumnName("ERR_CR_BY");
                entity.Property(e => e.ErrCrDt).HasColumnName("ERR_CR_DT");
                entity.Property(e => e.ErrUpBy).HasColumnName("ERR_UP_BY");
                entity.Property(e => e.ErrUpDt).HasColumnName("ERR_UP_DT");
            });

            // =========================
            // USER_MASTER
            // =========================
            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.ToTable("USER_MASTER");

                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
                entity.Property(e => e.UserName).HasColumnName("USER_NAME");
                entity.Property(e => e.UserPassword).HasColumnName("USER_PASSWORD");
                entity.Property(e => e.UserType).HasColumnName("USER_TYPE");
                entity.Property(e => e.UserCrBy).HasColumnName("USER_CR_BY");
                entity.Property(e => e.UserCrDt).HasColumnName("USER_CR_DT");
                entity.Property(e => e.UserUpBy).HasColumnName("USER_UP_BY");
                entity.Property(e => e.UserUpDt).HasColumnName("USER_UP_DT");
            });

            // =========================
            // MOTOR_POLICY
            // =========================
            modelBuilder.Entity<MotorPolicy>(entity =>
            {
                entity.ToTable("MOTOR_POLICY");

                entity.HasKey(e => e.PolUid);

                entity.Property(e => e.PolUid).HasColumnName("POL_UID");
                entity.Property(e => e.PolNo).HasColumnName("POL_NO");
                entity.Property(e => e.PolIssDt).HasColumnName("POL_ISS_DT");
                entity.Property(e => e.PolFmDt).HasColumnName("POL_FM_DT");
                entity.Property(e => e.PolToDt).HasColumnName("POL_TO_DT");
                entity.Property(e => e.PolAssrName).HasColumnName("POL_ASSR_NAME");
                entity.Property(e => e.PolAssrMobile).HasColumnName("POL_ASSR_MOBILE");
                entity.Property(e => e.PolCurrCode).HasColumnName("POL_CURR_CODE");
                entity.Property(e => e.PolGrossFcPrem).HasColumnName("POL_GROSS_FC_PREM");
                entity.Property(e => e.PolGrossLcPrem).HasColumnName("POL_GROSS_LC_PREM");
                entity.Property(e => e.PolVehMake).HasColumnName("POL_VEH_MAKE");
                entity.Property(e => e.PolVehModel).HasColumnName("POL_VEH_MODEL");
                entity.Property(e => e.PolVehChassisNo).HasColumnName("POL_VEH_CHASSIS_NO");
                entity.Property(e => e.PolVehEngineNo).HasColumnName("POL_VEH_ENGINE_NO");
                entity.Property(e => e.PolVehRegnNo).HasColumnName("POL_VEH_REGN_NO");
                entity.Property(e => e.PolVehValue).HasColumnName("POL_VEH_VALUE");
                entity.Property(e => e.PolApprStatus).HasColumnName("POL_APPR_STATUS");
                entity.Property(e => e.PolApprDt).HasColumnName("POL_APPR_DT");
                entity.Property(e => e.PolApprBy).HasColumnName("POL_APPR_BY");
                entity.Property(e => e.PolCrBy).HasColumnName("POL_CR_BY");
                entity.Property(e => e.PolCrDt).HasColumnName("POL_CR_DT");
                entity.Property(e => e.PolUpBy).HasColumnName("POL_UP_BY");
                entity.Property(e => e.PolUpDt).HasColumnName("POL_UP_DT");
            });

            // =========================
            // MOTOR_CLAIM
            // =========================
            modelBuilder.Entity<MotorClaim>(entity =>
            {
                entity.ToTable("MOTOR_CLAIM");

                entity.HasKey(e => e.ClmUid);

                entity.Property(e => e.ClmUid).HasColumnName("CLM_UID");
                entity.Property(e => e.ClmNo).HasColumnName("CLM_NO");
                entity.Property(e => e.ClmPolNo).HasColumnName("CLM_POL_NO");
                entity.Property(e => e.ClmPolFmDt).HasColumnName("CLM_POL_FM_DT");
                entity.Property(e => e.ClmPolToDt).HasColumnName("CLM_POL_TO_DT");
                entity.Property(e => e.ClmPolAssrName).HasColumnName("CLM_POL_ASSR_NAME");
                entity.Property(e => e.ClmPolAssrMob).HasColumnName("CLM_POL_ASSR_MOB");
                entity.Property(e => e.ClmLossDt).HasColumnName("CLM_LOSS_DT");
                entity.Property(e => e.ClmIntmDt).HasColumnName("CLM_INTM_DT");
                entity.Property(e => e.ClmRegDt).HasColumnName("CLM_REG_DT");
                entity.Property(e => e.ClmPolRepNo).HasColumnName("CLM_POL_REP_NO");
                entity.Property(e => e.ClmPolRepDtl).HasColumnName("CLM_POL_REP_DTL");
                entity.Property(e => e.ClmLossDesc).HasColumnName("CLM_LOSS_DESC");
                entity.Property(e => e.ClmVehMake).HasColumnName("CLM_VEH_MAKE");
                entity.Property(e => e.ClmVehModel).HasColumnName("CLM_VEH_MODEL");
                entity.Property(e => e.ClmVehChassisNo).HasColumnName("CLM_VEH_CHASSIS_NO");
                entity.Property(e => e.ClmVegEngineNo).HasColumnName("CLM_VEG_ENGINE_NO");
                entity.Property(e => e.ClmVehRegnNo).HasColumnName("CLM_VEH_REGN_NO");
                entity.Property(e => e.ClmVehValue).HasColumnName("CLM_VEH_VALUE");
                entity.Property(e => e.ClmSurCrYn).HasColumnName("CLM_SUR_CR_YN");
                entity.Property(e => e.ClmSurApprYn).HasColumnName("CLM_SUR_APPR_YN");
                entity.Property(e => e.ClmApprStatus).HasColumnName("CLM_APPR_STATUS");
                entity.Property(e => e.ClmSurNo).HasColumnName("CLM_SUR_NO");
                entity.Property(e => e.ClmCrBy).HasColumnName("CLM_CR_BY");
                entity.Property(e => e.ClmCrDt).HasColumnName("CLM_CR_DT");
                entity.Property(e => e.ClmUpBy).HasColumnName("CLM_UP_BY");
                entity.Property(e => e.ClmUpDt).HasColumnName("CLM_UP_DT");
            });

            // =========================
            // MOTOR_CLM_SUR_HDR
            // =========================
            modelBuilder.Entity<MotorClmSurHdr>(entity =>
            {
                entity.ToTable("MOTOR_CLM_SUR_HDR");

                entity.HasKey(e => e.SurUid);

                entity.Property(e => e.SurUid).HasColumnName("SUR_UID");
                entity.Property(e => e.SurClmUid).HasColumnName("SUR_CLM_UID");
                entity.Property(e => e.SurClmNo).HasColumnName("SUR_CLM_NO");
                entity.Property(e => e.SurNo).HasColumnName("SUR_NO");
                entity.Property(e => e.SurDate).HasColumnName("SUR_DATE");
                entity.Property(e => e.SurLocation).HasColumnName("SUR_LOCATION");
                entity.Property(e => e.SurChassisNo).HasColumnName("SUR_CHASSIS_NO");
                entity.Property(e => e.SurRegnNo).HasColumnName("SUR_REGN_NO");
                entity.Property(e => e.SurEngineNo).HasColumnName("SUR_ENGINE_NO");
                entity.Property(e => e.SurCurr).HasColumnName("SUR_CURR");
                entity.Property(e => e.SurFcAmt).HasColumnName("SUR_FC_AMT");
                entity.Property(e => e.SurLcAmt).HasColumnName("SUR_LC_AMT");
                entity.Property(e => e.SurStatus).HasColumnName("SUR_STATUS");
                entity.Property(e => e.SurApprSts).HasColumnName("SUR_APPR_STS");
                entity.Property(e => e.SurApprDt).HasColumnName("SUR_APPR_DT");
                entity.Property(e => e.SurApprBy).HasColumnName("SUR_APPR_BY");
                entity.Property(e => e.SurCrBy).HasColumnName("SUR_CR_BY");
                entity.Property(e => e.SurCrDt).HasColumnName("SUR_CR_DT");
                entity.Property(e => e.SurUpBy).HasColumnName("SUR_UP_BY");
                entity.Property(e => e.SurUpDt).HasColumnName("SUR_UP_DT");
            });

            // =========================
            // MOTOR_CLM_SUR_DTL
            // =========================
            modelBuilder.Entity<MotorClmSurDtl>(entity =>
            {
                entity.ToTable("MOTOR_CLM_SUR_DTL");

                entity.HasKey(e => e.SurdUid);

                entity.Property(e => e.SurdUid).HasColumnName("SURD_UID");
                entity.Property(e => e.SurdSurUid).HasColumnName("SURD_SUR_UID");
                entity.Property(e => e.SurdItemCode).HasColumnName("SURD_ITEM_CODE");
                entity.Property(e => e.SurdType).HasColumnName("SURD_TYPE");
                entity.Property(e => e.SurdUnitPrice).HasColumnName("SURD_UNIT_PRICE");
                entity.Property(e => e.SurdQuantity).HasColumnName("SURD_QUANTITY");
                entity.Property(e => e.SurdFcAmt).HasColumnName("SURD_FC_AMT");
                entity.Property(e => e.SurdLcAmt).HasColumnName("SURD_LC_AMT");
                entity.Property(e => e.SurdRemarks).HasColumnName("SURD_REMARKS");
                entity.Property(e => e.SurdCrBy).HasColumnName("SURD_CR_BY");
                entity.Property(e => e.SurdCrDt).HasColumnName("SURD_CR_DT");
                entity.Property(e => e.SurdUpBy).HasColumnName("SURD_UP_BY");
                entity.Property(e => e.SurdUpDt).HasColumnName("SURD_UP_DT");
            });

            // =========================
            // MOTOR_CLM_SUR_DTL_HIST
            // =========================
            modelBuilder.Entity<MotorClmSurDtlHist>(entity =>
            {
                entity.ToTable("MOTOR_CLM_SUR_DTL_HIST");

                entity.HasKey(e => new { e.SurdhUid, e.SurdhSrl });

                entity.Property(e => e.SurdhUid).HasColumnName("SURDH_UID");
                entity.Property(e => e.SurdhSrl).HasColumnName("SURDH_SRL");
                entity.Property(e => e.SurdhAction).HasColumnName("SURDH_ACTION");
                entity.Property(e => e.SurdhItemCode).HasColumnName("SURDH_ITEM_CODE");
                entity.Property(e => e.SurdhType).HasColumnName("SURDH_TYPE");
                entity.Property(e => e.SurdhUnitPrice).HasColumnName("SURDH_UNIT_PRICE");
                entity.Property(e => e.SurdhQuantity).HasColumnName("SURDH_QUANTITY");
                entity.Property(e => e.SurdhFcAmt).HasColumnName("SURDH_FC_AMT");
                entity.Property(e => e.SurdhLcAmt).HasColumnName("SURDH_LC_AMT");
                entity.Property(e => e.SurdhRemarks).HasColumnName("SURDH_REMARKS");
                entity.Property(e => e.SurdhCrBy).HasColumnName("SURDH_CR_BY");
                entity.Property(e => e.SurdhCrDt).HasColumnName("SURDH_CR_DT");
                entity.Property(e => e.SurdhUpBy).HasColumnName("SURDH_UP_BY");
                entity.Property(e => e.SurdhUpDt).HasColumnName("SURDH_UP_DT");
            });
        }

    }
}
