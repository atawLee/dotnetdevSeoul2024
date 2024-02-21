using SimpleWMS.Data;
using SimpleWMS.Database.Entities;
using SimpleWMS.Models.Services;

namespace SimpleWMS.ViewModels;

public class StockHistoryViewModel
{
    private readonly WareHouseManagementService _service;

    public string? SearchItemName { get; set; }
    public string? SearchBarcode { get; set; }
    public bool SearchStockIn { get; set; }
    public bool SearchStockOut { get; set; }
    public string ModalTitle { get; set; } = "";
    public StockTransactionType CurrentModal { get; set; }
    public DateTime StockInOutDate { get; set; } = DateTime.Today;
    public int StockInOutQuantity { get; set; }
    public int SelectedStockInventoryId { get; set; }

    public List<InventoryItem> InventoryItems { get; private set; } = new List<InventoryItem>();
    public List<StockHistoryDTO> StockHistorySearchResults { get; private set; } = new List<StockHistoryDTO>();

    public StockHistoryViewModel(WareHouseManagementService service)
    {
        _service = service;
        InitializeViewModel();
    }

    public void InitializeViewModel()
    {
        InventoryItems = _service.GetAllInventoryItems();
        Search();
    }

    public void Search()
    {
        StockHistorySearchResults = _service.GetStockInOutsFiltered(SearchItemName, SearchBarcode, DetermineTransactionType());
    }

    private StockTransactionType? DetermineTransactionType()
    {
        if (SearchStockIn && !SearchStockOut)
        {
            return StockTransactionType.StockIn;
        }
        else if (!SearchStockIn && SearchStockOut)
        {
            return StockTransactionType.StockOut;
        }

        return null;
    }

    public void ShowModal(StockTransactionType modalType)
    {
        CurrentModal = modalType;
    }

    public void AddData()
    {
        try
        {
            var stockType = CurrentModal;
            var dto = new StockCommandDTO(SelectedStockInventoryId, StockInOutQuantity, stockType);
            _service.InsertStockInOut(dto, dto.Quantity, stockType);

            Search();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error adding stock in/out data: {ex.Message}");
        }
    }

    public void SetModalType(StockTransactionType modalType)
    {
        ModalTitle = modalType == StockTransactionType.StockIn ? "입고 추가" : "출고 추가";
    }
}