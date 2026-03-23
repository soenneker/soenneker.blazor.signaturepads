export class SignaturePadsInterop {
    constructor() {
        this._instances = new Map();
        this._resizeObservers = new Map();
    }

    create(canvas, elementId, options) {
        if (!canvas)
            throw new Error("A canvas element reference is required.");

        this.destroy(elementId);

        this._resizeCanvas(canvas);

        const signaturePad = new window.SignaturePad(canvas, options ?? {});

        this._instances.set(elementId, {
            canvas,
            signaturePad
        });
    }

    createResizeObserver(elementId, preserveDrawingOnResize = true) {
        const instance = this._getInstance(elementId);

        this.destroyResizeObserver(elementId);

        const observer = new ResizeObserver(() => {
            this._resizeCanvas(instance.canvas, instance.signaturePad, preserveDrawingOnResize);
        });

        observer.observe(instance.canvas);
        this._resizeObservers.set(elementId, observer);
    }

    destroyResizeObserver(elementId) {
        const observer = this._resizeObservers.get(elementId);

        if (!observer)
            return;

        observer.disconnect();
        this._resizeObservers.delete(elementId);
    }

    destroy(elementId) {
        this.destroyResizeObserver(elementId);

        const instance = this._instances.get(elementId);

        if (!instance)
            return;

        instance.signaturePad.off();
        this._instances.delete(elementId);
    }

    clear(elementId) {
        this._getInstance(elementId).signaturePad.clear();
    }

    isEmpty(elementId) {
        return this._getInstance(elementId).signaturePad.isEmpty();
    }

    toDataUrl(elementId, type = "image/png", encoderOptions = null) {
        return this._getInstance(elementId).signaturePad.toDataURL(type, encoderOptions ?? undefined);
    }

    toSvg(elementId, options = null) {
        return this._getInstance(elementId).signaturePad.toSVG(options ?? undefined);
    }

    toData(elementId) {
        const data = this._getInstance(elementId).signaturePad.toData();

        return data.map((group) => ({
            PenColor: group.penColor,
            DotSize: group.dotSize,
            MinWidth: group.minWidth,
            MaxWidth: group.maxWidth,
            VelocityFilterWeight: group.velocityFilterWeight,
            CompositeOperation: group.compositeOperation,
            Points: (group.points ?? []).map((point) => ({
                Time: point.time,
                X: point.x,
                Y: point.y,
                Pressure: point.pressure
            }))
        }));
    }

    fromData(elementId, data, clear = true) {
        const normalized = (data ?? []).map((group) => ({
            penColor: group.PenColor ?? group.penColor,
            dotSize: group.DotSize ?? group.dotSize,
            minWidth: group.MinWidth ?? group.minWidth,
            maxWidth: group.MaxWidth ?? group.maxWidth,
            velocityFilterWeight: group.VelocityFilterWeight ?? group.velocityFilterWeight,
            compositeOperation: group.CompositeOperation ?? group.compositeOperation,
            points: (group.Points ?? group.points ?? []).map((point) => ({
                time: point.Time ?? point.time,
                x: point.X ?? point.x,
                y: point.Y ?? point.y,
                pressure: point.Pressure ?? point.pressure ?? 0
            }))
        }));

        this._getInstance(elementId).signaturePad.fromData(normalized, { clear });
    }

    async fromDataUrl(elementId, dataUrl, options = null) {
        await this._getInstance(elementId).signaturePad.fromDataURL(dataUrl, options ?? undefined);
    }

    redraw(elementId) {
        this._getInstance(elementId).signaturePad.redraw();
    }

    on(elementId) {
        this._getInstance(elementId).signaturePad.on();
    }

    off(elementId) {
        this._getInstance(elementId).signaturePad.off();
    }

    setOptions(elementId, options) {
        if (!options)
            return;

        const signaturePad = this._getInstance(elementId).signaturePad;

        if (options.dotSize !== undefined)
            signaturePad.dotSize = options.dotSize;

        if (options.minWidth !== undefined)
            signaturePad.minWidth = options.minWidth;

        if (options.maxWidth !== undefined)
            signaturePad.maxWidth = options.maxWidth;

        if (options.throttle !== undefined)
            signaturePad.throttle = options.throttle;

        if (options.minDistance !== undefined)
            signaturePad.minDistance = options.minDistance;

        if (options.backgroundColor !== undefined)
            signaturePad.backgroundColor = options.backgroundColor;

        if (options.penColor !== undefined)
            signaturePad.penColor = options.penColor;

        if (options.velocityFilterWeight !== undefined)
            signaturePad.velocityFilterWeight = options.velocityFilterWeight;

        if (options.compositeOperation !== undefined)
            signaturePad.compositeOperation = options.compositeOperation;

        if (signaturePad.isEmpty())
            signaturePad.clear();
    }

    _getInstance(elementId) {
        const instance = this._instances.get(elementId);

        if (!instance)
            throw new Error(`SignaturePad instance '${elementId}' was not found.`);

        return instance;
    }

    _resizeCanvas(canvas, signaturePad = null, preserveDrawing = true) {
        const width = this._getCanvasWidth(canvas);
        const height = this._getCanvasHeight(canvas);
        const ratio = Math.max(window.devicePixelRatio || 1, 1);

        if (width <= 0 || height <= 0)
            return;

        const scaledWidth = Math.floor(width * ratio);
        const scaledHeight = Math.floor(height * ratio);

        if (canvas.width === scaledWidth && canvas.height === scaledHeight)
            return;

        const data = signaturePad && preserveDrawing && !signaturePad.isEmpty()
            ? signaturePad.toData()
            : null;

        canvas.width = scaledWidth;
        canvas.height = scaledHeight;

        const context = canvas.getContext("2d");
        context.scale(ratio, ratio);

        if (!signaturePad)
            return;

        if (data && data.length > 0)
            signaturePad.fromData(data);
        else
            signaturePad.clear();
    }

    _getCanvasWidth(canvas) {
        return canvas.offsetWidth || canvas.clientWidth || Number.parseInt(canvas.getAttribute("width") ?? "0", 10) || 300;
    }

    _getCanvasHeight(canvas) {
        return canvas.offsetHeight || canvas.clientHeight || Number.parseInt(canvas.getAttribute("height") ?? "0", 10) || 150;
    }
}

window.SignaturePadsInterop = new SignaturePadsInterop();
