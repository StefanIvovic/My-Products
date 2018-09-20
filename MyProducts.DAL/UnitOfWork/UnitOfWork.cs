using System;
using System.Diagnostics;
using MyProducts.DAL.GenericRepository;

namespace MyProducts.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _context = null;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Manufacturer> _manufacturerRepository;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<Supplier> _supplierRepository;


        public UnitOfWork()
        {
            _context = new ProductContext();
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new GenericRepository<Product>(_context);
                return this._productRepository;
            }
        }

        public GenericRepository<Manufacturer> ManufacturerRepository
        {
            get
            {
                if (this._manufacturerRepository == null)
                    this._manufacturerRepository = new GenericRepository<Manufacturer>(_context);
                return this._manufacturerRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository<Category>(_context);
                return this._categoryRepository;
            }
        }

        public GenericRepository<Supplier> SupplierRepository
        {
            get
            {
                if (this._supplierRepository == null)
                    this._supplierRepository = new GenericRepository<Supplier>(_context);
                return this._supplierRepository;
            }
        }

        public bool Save()
        {
            _context.SaveChanges();
            return true;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Debug.WriteLine("UnitOfWork je oslobodjen");
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
