package com.example.demo;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import jakarta.validation.constraints.DecimalMin;
import jakarta.validation.constraints.Digits;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;

import java.math.BigDecimal;

@Entity // This annotation indicates that this class is a JPA entity
@Table(name = "medical_supplies")
public class MedicalSupply {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Name is required") // This annotation indicates that the field is required
    @Size(max = 100, message = "Name must be 100 characters or fewer")
    private String name;

    @NotBlank(message = "Category is required")
    @Size(max = 100, message = "Category must be 100 characters or fewer")
    private String category;

    @NotBlank(message = "Vendor is required")
    @Size(max = 100, message = "Vendor must be 100 characters or fewer")
    private String vendor;

    @NotNull(message = "Unit price is required")
    @DecimalMin(value = "0.00", message = "Unit price cannot be negative")
    @Digits(integer = 8, fraction = 2, message = "Unit price can have at most 8 digits and 2 decimal places")

    @Column(name = "unit_price")
    private BigDecimal unitPrice;

    @NotNull(message = "Quantity is required")
    @Min(value = 0, message = "Quantity cannot be negative")
    private Integer quantity;

    @Size(max = 255, message = "Description must be 255 characters or fewer")
    private String description;

    public MedicalSupply() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;

    }
    public void setName(String name) {
        this.name = name;
    }

    public String getCategory() {
        return category;
    }
    public void setCategory(String category) {
        this.category = category;
    }

    public String getVendor() {
        return vendor;
    }

    public void setVendor(String vendor) {
        this.vendor = vendor;
    }

    public BigDecimal getUnitPrice() {
        return unitPrice;

    }
    public void setUnitPrice(BigDecimal unitPrice) {
        this.unitPrice = unitPrice;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
