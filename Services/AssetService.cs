using AssetB.Models;
using AssetB.DTO;
using AssetB.Helpers;
using System.Linq;
using System;
using System.Collections.Generic;

namespace AssetB.Services
{
    public interface IAssetService
    {
        IEnumerable<Asset_Kind1> GetAssetKind(string kindno);
        IEnumerable<AssetMaintainDTO> GetAll();
        IEnumerable<AssetMaintainDTO> GetByAssno(string id);
        AssetMaintain Create(AssetMaintain asset);
        void Update(AssetMaintain asset);
        void Delete(string id);
    }
    public class AssetService : IAssetService
    {
        private DataContext _context;
        public AssetService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Asset_Kind1> GetAssetKind(string kindno)
        {
            var assKind = _context.Asset_Kinds.AsQueryable();
            if (!String.IsNullOrEmpty(kindno))
                assKind = assKind.Where(x => x.kind == kindno);
            return assKind;
        }
        public IEnumerable<AssetMaintainDTO> GetAll()
        {
            var kinds = _context.Asset_Kinds;
            var assets = _context.AssetMaintains;
            var all = (from k in assets join b in kinds on k.AssetKind equals b.kind select new AssetMaintainDTO(){
                Asset_ID = k.Asset_ID,
                AssetKind = k.AssetKind,
                KindName = b.kindna,
                Name = k.Name,
                Spec = k.Spec,
                Locat = k.Locat,
                Stat = k.Stat,
                recdate = k.recdate,
                intime = k.intime,
                uptime = k.uptime
            });

            return all;
        }

        public IEnumerable<AssetMaintainDTO> GetByAssno(string id)
        {
            var getAll = _context.AssetMaintains.AsQueryable();
            var kinds = _context.Asset_Kinds;
            //if (!String.IsNullOrEmpty(id)) sementara anj
            //{
                getAll = getAll.Where(x => x.Asset_ID == id);
                var all = (from k in getAll join b in kinds on k.AssetKind equals b.kind select new AssetMaintainDTO(){
                    Asset_ID = k.Asset_ID,
                    AssetKind = k.AssetKind,
                    KindName = b.kindna,
                    Name = k.Name.TrimEnd(),
                    Spec = k.Spec.TrimEnd(),
                    Locat = k.Locat.TrimEnd(),
                    Stat = k.Stat,
                    recdate = k.recdate,
                    intime = k.intime,
                    uptime = k.uptime
                });

                //var kk = gas.Join
                return all;
            //}
            
            //return getAll;
        }

        public AssetMaintain Create(AssetMaintain asset)
        {
            if (_context.AssetMaintains.Any(x => x.Asset_ID == asset.Asset_ID))
                throw new AppException("Asset number " + asset.Asset_ID + " is already exist");
            asset.intime = asset.intime.ToLocalTime();
            asset.recdate = asset.recdate.ToLocalTime();
            _context.AssetMaintains.Add(asset);
            _context.SaveChanges();

            return asset;
        }

        public void Update(AssetMaintain asset)
        {
            var selectedAsset = _context.AssetMaintains.Find(asset.Asset_ID);

            //ganti kode asset (saat di frontend akan post, Asset ID harus diisi, tdk blh null ato kosong)
            //if(!string.IsNullOrWhiteSpace(asset.Asset_ID) && asset.Asset_ID != selectedAsset.Asset_ID.Trim())
            //{
            //    //update asset code
            //    if (_context.AssetMaintains.Any(x => x.Asset_ID == asset.Asset_ID))
            //        throw new AppException("Asset number " + asset.Asset_ID + " is already exist");

            //    selectedAsset.Asset_ID = asset.Asset_ID;
            //}

            

            //update asset kind
            if (!string.IsNullOrWhiteSpace(asset.AssetKind))
                selectedAsset.AssetKind = asset.AssetKind;
            
            //update name
            if (!string.IsNullOrWhiteSpace(asset.Name))
                selectedAsset.Name = asset.Name;

            //update spec
            if (!string.IsNullOrWhiteSpace(asset.Spec))
                selectedAsset.Spec = asset.Spec;

            //update loc
            if (!string.IsNullOrWhiteSpace(asset.Locat))
                selectedAsset.Locat = asset.Locat;

            //recdate
            if (!string.IsNullOrWhiteSpace(asset.recdate.ToString()))
                selectedAsset.recdate = asset.recdate.ToLocalTime();

            selectedAsset.uptime = DateTime.Now;

            _context.AssetMaintains.Update(selectedAsset);
            _context.SaveChanges();

        }
        public void Delete(string id)
        {
            var asset = _context.AssetMaintains.Find(id);
            if (asset != null)
            {
                _context.AssetMaintains.Remove(asset);
                _context.SaveChanges();
            }
        }
    }
}